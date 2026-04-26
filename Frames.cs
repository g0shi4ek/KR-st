using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace KR
{
    /// <summary>
    /// Variant 11 frame protocol for point-to-point file transfer over RS232C.
    ///
    /// Frame structure:
    ///   [0xFF] [FrameType] [payload bytes...]
    ///
    /// Frame types:
    ///   UPLINK        – connection request (Sender → Receiver)
    ///   ACK_UPLINK    – connection accepted
    ///   RET_UPLINK    – connection rejected / retry
    ///   DOWNLINK      – disconnect request
    ///   ACK_DOWNLINK  – disconnect acknowledged
    ///
    ///   FILE_INFO     – file metadata: [name_len_2B LE][name UTF-8][total_chunks_4B LE]
    ///   ACK_FILE_INFO – receiver ready
    ///   RET_FILE_INFO – receiver not ready / error
    ///
    ///   CHUNK         – one encoded chunk: [chunk_index_4B LE][data_len_2B LE][hamming-encoded data]
    ///   ACK_CHUNK     – chunk received OK
    ///   RET_CHUNK     – chunk error, please resend
    ///
    ///   PACE_SLOW     – application-level pace control: slow down
    ///   PACE_NORMAL   – application-level pace control: normal speed
    ///   PACE_FAST     – application-level pace control: fast
    ///
    ///   TRANSFER_DONE – all chunks sent
    ///   ACK_DONE      – transfer complete acknowledged
    /// </summary>
    internal class Frames
    {
        // ── Frame type byte values ────────────────────────────────────────────
        public enum FrameType : byte
        {
            UPLINK        = 0x01,
            ACK_UPLINK    = 0x02,
            RET_UPLINK    = 0x03,
            DOWNLINK      = 0x04,
            ACK_DOWNLINK  = 0x05,

            FILE_INFO     = 0x10,
            ACK_FILE_INFO = 0x11,
            RET_FILE_INFO = 0x12,

            CHUNK         = 0x20,
            ACK_CHUNK     = 0x21,
            RET_CHUNK     = 0x22,

            PACE_SLOW     = 0x30,
            PACE_NORMAL   = 0x31,
            PACE_FAST     = 0x32,

            TRANSFER_DONE = 0x40,
            ACK_DONE      = 0x41,
        }

        // ── Pace levels (ms delay between chunks) ────────────────────────────
        public enum PaceLevel { Slow = 500, Normal = 100, Fast = 10 }

        // ── Test error injection mode ─────────────────────────────────────────
        /// <summary>
        /// Controls artificial bit-error injection for demonstration purposes.
        /// None    – normal operation, no errors injected.
        /// OneBit  – one bit is flipped in the Hamming-encoded payload of every
        ///           CHUNK frame; the [7,4] decoder corrects it automatically.
        /// TwoBit  – two bits are flipped; the decoder detects but cannot correct
        ///           the error and sends RET_CHUNK; after MAX_RETRIES the transfer fails.
        /// </summary>
        public enum ErrorMode { None, OneBit, TwoBit }

        /// <summary>Current test error injection mode (set from UI).</summary>
        public ErrorMode TestErrorMode { get; set; } = ErrorMode.None;

        // ── Events ────────────────────────────────────────────────────────────
        public event Action<string, int>  OnFileInfoReceived;   // (fileName, totalChunks)
        public event Action<int, byte[]>  OnChunkReceived;      // (chunkIndex, rawData)
        public event Action               OnTransferComplete;
        public event Action               OnConnected;
        public event Action               OnDisconnected;
        public event Action<PaceLevel>    OnPaceChanged;

        // ── State ─────────────────────────────────────────────────────────────
        public bool IsConnected { get; private set; }
        public PaceLevel CurrentPace { get; private set; } = PaceLevel.Normal;

        // ── UI text box ───────────────────────────────────────────────────────
        public RichTextBox LogBox;

        private readonly Coding _coder = new Coding();

        private const byte START      = 0xFF;
        private const int  MAX_RETRIES = 3;

        // ── Chunk ACK synchronisation (used by SendChunk) ─────────────────────
        // The DataReceived handler sets these when ACK_CHUNK / RET_CHUNK arrives
        // while a SendChunk call is waiting.
        private volatile bool _waitingForChunkAck = false;
        private volatile bool _chunkAckReceived   = false;
        private volatile bool _chunkRetReceived   = false;
        private readonly ManualResetEventSlim _chunkAckEvent = new ManualResetEventSlim(false);

        // ── Chunk size (raw bytes per chunk before Hamming encoding) ──────────
        public const int CHUNK_SIZE = 128;

        // ─────────────────────────────────────────────────────────────────────
        // Incoming frame dispatcher
        // ─────────────────────────────────────────────────────────────────────
        public void FrameAction(byte frameTypeByte, SerialPort port)
        {
            if (!Enum.IsDefined(typeof(FrameType), frameTypeByte))
            {
                Log($"[{DateTime.Now:HH:mm:ss}] Unknown frame 0x{frameTypeByte:X2}", Color.OrangeRed);
                return;
            }

            var ft = (FrameType)frameTypeByte;
            Log($"[{DateTime.Now:HH:mm:ss}] ← {ft}", Color.Gray);

            switch (ft)
            {
                // ── Connection ────────────────────────────────────────────────
                case FrameType.UPLINK:
                    SendControlFrame(FrameType.ACK_UPLINK, port);
                    IsConnected = true;
                    OnConnected?.Invoke();
                    break;

                case FrameType.ACK_UPLINK:
                    IsConnected = true;
                    OnConnected?.Invoke();
                    break;

                case FrameType.RET_UPLINK:
                    IsConnected = false;
                    Log($"[{DateTime.Now:HH:mm:ss}] Connection refused.", Color.OrangeRed);
                    break;

                case FrameType.DOWNLINK:
                    IsConnected = false;
                    SendControlFrame(FrameType.ACK_DOWNLINK, port);
                    OnDisconnected?.Invoke();
                    break;

                case FrameType.ACK_DOWNLINK:
                    IsConnected = false;
                    OnDisconnected?.Invoke();
                    break;

                // ── File info ─────────────────────────────────────────────────
                case FrameType.FILE_INFO:
                {
                    try
                    {
                        // Read: [name_len 2B LE][name bytes][total_chunks 4B LE]
                        var lenBuf = ReadExact(port, 2);
                        int nameLen = lenBuf[0] | (lenBuf[1] << 8);
                        var nameBuf = ReadExact(port, nameLen);
                        var chunksBuf = ReadExact(port, 4);
                        string fileName = Encoding.UTF8.GetString(nameBuf);
                        int totalChunks = BitConverter.ToInt32(chunksBuf, 0);

                        Log($"[{DateTime.Now:HH:mm:ss}] FILE_INFO: \"{fileName}\", {totalChunks} chunks", Color.DodgerBlue);
                        SendControlFrame(FrameType.ACK_FILE_INFO, port);
                        OnFileInfoReceived?.Invoke(fileName, totalChunks);
                    }
                    catch (Exception ex)
                    {
                        Log($"[{DateTime.Now:HH:mm:ss}] FILE_INFO parse error: {ex.Message}", Color.Crimson);
                        SendControlFrame(FrameType.RET_FILE_INFO, port);
                    }
                    break;
                }

                case FrameType.ACK_FILE_INFO:
                    Log($"[{DateTime.Now:HH:mm:ss}] Receiver ready for file.", Color.DodgerBlue);
                    break;

                case FrameType.RET_FILE_INFO:
                    Log($"[{DateTime.Now:HH:mm:ss}] Receiver rejected file info.", Color.Crimson);
                    break;

                // ── Chunk ─────────────────────────────────────────────────────
                case FrameType.CHUNK:
                {
                    try
                    {
                        // [chunk_index 4B LE][data_len 2B LE][hamming-encoded data]
                        var idxBuf  = ReadExact(port, 4);
                        var lenBuf  = ReadExact(port, 2);
                        int chunkIdx = BitConverter.ToInt32(idxBuf, 0);
                        int dataLen  = lenBuf[0] | (lenBuf[1] << 8);
                        var encoded  = ReadExact(port, dataLen);

                        var decoded = _coder.DecodeBytes(encoded);
                        if (decoded == null)
                        {
                            Log($"[{DateTime.Now:HH:mm:ss}] CHUNK #{chunkIdx} decode error → RET", Color.Crimson);
                            SendControlFrame(FrameType.RET_CHUNK, port);
                            break;
                        }

                        Log($"[{DateTime.Now:HH:mm:ss}] CHUNK #{chunkIdx} OK ({decoded.Length} bytes)", Color.DodgerBlue);
                        SendControlFrame(FrameType.ACK_CHUNK, port);
                        OnChunkReceived?.Invoke(chunkIdx, decoded);
                    }
                    catch (Exception ex)
                    {
                        Log($"[{DateTime.Now:HH:mm:ss}] CHUNK read error: {ex.Message}", Color.Crimson);
                        SendControlFrame(FrameType.RET_CHUNK, port);
                    }
                    break;
                }

                // ── Chunk ACK/RET — signal waiting SendChunk ──────────────────
                case FrameType.ACK_CHUNK:
                    if (_waitingForChunkAck)
                    {
                        _chunkAckReceived = true;
                        _chunkRetReceived = false;
                        _chunkAckEvent.Set();
                    }
                    break;

                case FrameType.RET_CHUNK:
                    if (_waitingForChunkAck)
                    {
                        _chunkRetReceived = true;
                        _chunkAckReceived = false;
                        _chunkAckEvent.Set();
                    }
                    break;

                // ── Pace control ──────────────────────────────────────────────
                case FrameType.PACE_SLOW:
                    CurrentPace = PaceLevel.Slow;
                    Log($"[{DateTime.Now:HH:mm:ss}] Pace → SLOW ({(int)PaceLevel.Slow} ms)", Color.DarkOrange);
                    OnPaceChanged?.Invoke(PaceLevel.Slow);
                    break;

                case FrameType.PACE_NORMAL:
                    CurrentPace = PaceLevel.Normal;
                    Log($"[{DateTime.Now:HH:mm:ss}] Pace → NORMAL ({(int)PaceLevel.Normal} ms)", Color.DarkOrange);
                    OnPaceChanged?.Invoke(PaceLevel.Normal);
                    break;

                case FrameType.PACE_FAST:
                    CurrentPace = PaceLevel.Fast;
                    Log($"[{DateTime.Now:HH:mm:ss}] Pace → FAST ({(int)PaceLevel.Fast} ms)", Color.DarkOrange);
                    OnPaceChanged?.Invoke(PaceLevel.Fast);
                    break;

                // ── Transfer done ─────────────────────────────────────────────
                case FrameType.TRANSFER_DONE:
                    SendControlFrame(FrameType.ACK_DONE, port);
                    OnTransferComplete?.Invoke();
                    Log($"[{DateTime.Now:HH:mm:ss}] Transfer complete.", Color.Green);
                    break;

                case FrameType.ACK_DONE:
                    OnTransferComplete?.Invoke();
                    Log($"[{DateTime.Now:HH:mm:ss}] Transfer acknowledged.", Color.Green);
                    break;
            }
        }

        // ─────────────────────────────────────────────────────────────────────
        // Send helpers
        // ─────────────────────────────────────────────────────────────────────

        /// <summary>Send a control frame (no payload).</summary>
        public void SendControlFrame(FrameType ft, SerialPort port)
        {
            EnsureOpen(port);
            port.Write(new byte[] { START, (byte)ft }, 0, 2);
            Log($"[{DateTime.Now:HH:mm:ss}] → {ft}", Color.SlateGray);
        }

        /// <summary>Send FILE_INFO frame.</summary>
        public void SendFileInfo(string fileName, int totalChunks, SerialPort port)
        {
            EnsureOpen(port);
            var nameBytes = Encoding.UTF8.GetBytes(fileName);
            var payload = new List<byte> { START, (byte)FrameType.FILE_INFO };
            payload.Add((byte)(nameBytes.Length & 0xFF));
            payload.Add((byte)((nameBytes.Length >> 8) & 0xFF));
            payload.AddRange(nameBytes);
            payload.AddRange(BitConverter.GetBytes(totalChunks));
            port.Write(payload.ToArray(), 0, payload.Count);
            Log($"[{DateTime.Now:HH:mm:ss}] → FILE_INFO \"{fileName}\" ({totalChunks} chunks)", Color.SlateGray);
        }

        /// <summary>
        /// Send a single CHUNK frame with Hamming encoding.
        /// Waits for ACK_CHUNK (signalled by FrameAction via _chunkAckEvent).
        /// Returns true if ACK received within MAX_RETRIES attempts.
        /// </summary>
        public bool SendChunk(int chunkIndex, byte[] rawData, SerialPort port)
        {
            var encoded = _coder.EncodeBytes(rawData);

            for (int attempt = 0; attempt < MAX_RETRIES; attempt++)
            {
                // ── Test error injection ──────────────────────────────────────
                // Make a working copy so the original encoded array stays intact
                // for retry attempts (we re-inject on every attempt for clarity).
                byte[] toSend = (byte[])encoded.Clone();
                if (TestErrorMode != ErrorMode.None && toSend.Length > 0)
                {
                    // Flip bit 0 of byte 0
                    toSend[0] ^= 0x01;
                    string errDesc = "1-bit error injected";
                    if (TestErrorMode == ErrorMode.TwoBit && toSend.Length > 1)
                    {
                        // Flip bit 1 of byte 1 (different byte → uncorrectable)
                        toSend[1] ^= 0x02;
                        errDesc = "2-bit error injected";
                    }
                    Log($"[{DateTime.Now:HH:mm:ss}] ⚡ TEST: {errDesc} in CHUNK #{chunkIndex}", Color.Orange);
                }

                // Prepare event
                _chunkAckReceived   = false;
                _chunkRetReceived   = false;
                _waitingForChunkAck = true;
                _chunkAckEvent.Reset();

                EnsureOpen(port);
                var payload = new List<byte> { START, (byte)FrameType.CHUNK };
                payload.AddRange(BitConverter.GetBytes(chunkIndex));
                payload.Add((byte)(toSend.Length & 0xFF));
                payload.Add((byte)((toSend.Length >> 8) & 0xFF));
                payload.AddRange(toSend);
                port.Write(payload.ToArray(), 0, payload.Count);
                Log($"[{DateTime.Now:HH:mm:ss}] → CHUNK #{chunkIndex} ({rawData.Length} bytes, attempt {attempt + 1})", Color.SlateGray);

                // Wait up to 3 seconds for ACK or RET (signalled by FrameAction)
                bool signalled = _chunkAckEvent.Wait(3000);
                _waitingForChunkAck = false;

                if (signalled && _chunkAckReceived)
                {
                    Log($"[{DateTime.Now:HH:mm:ss}] ← ACK_CHUNK #{chunkIndex}", Color.Gray);
                    return true;
                }

                if (signalled && _chunkRetReceived)
                    Log($"[{DateTime.Now:HH:mm:ss}] ← RET_CHUNK #{chunkIndex}, retrying...", Color.OrangeRed);
                else
                    Log($"[{DateTime.Now:HH:mm:ss}] Timeout waiting for ACK_CHUNK #{chunkIndex}", Color.OrangeRed);
            }

            Log($"[{DateTime.Now:HH:mm:ss}] CHUNK #{chunkIndex} failed after {MAX_RETRIES} attempts.", Color.Crimson);
            return false;
        }

        /// <summary>Send a pace-control frame to the remote side.</summary>
        public void SendPace(PaceLevel pace, SerialPort port)
        {
            FrameType ft = pace switch
            {
                PaceLevel.Slow   => FrameType.PACE_SLOW,
                PaceLevel.Fast   => FrameType.PACE_FAST,
                _                => FrameType.PACE_NORMAL,
            };
            SendControlFrame(ft, port);
            CurrentPace = pace;
        }

        // ─────────────────────────────────────────────────────────────────────
        // Utility
        // ─────────────────────────────────────────────────────────────────────

        private static byte[] ReadExact(SerialPort port, int count)
        {
            var buf  = new byte[count];
            int read = 0;
            while (read < count)
            {
                int got = port.Read(buf, read, count - read);
                if (got == 0) throw new IOException("Port closed unexpectedly.");
                read += got;
            }
            return buf;
        }

        private static void EnsureOpen(SerialPort port)
        {
            if (!port.IsOpen) port.Open();
        }

        private void Log(string text, Color color)
        {
            if (LogBox == null) return;
            if (LogBox.InvokeRequired)
                LogBox.Invoke(new Action(() => AppendLog(text, color)));
            else
                AppendLog(text, color);
        }

        private void AppendLog(string text, Color color)
        {
            LogBox.SelectionStart  = LogBox.TextLength;
            LogBox.SelectionLength = 0;
            LogBox.SelectionColor  = color;
            LogBox.AppendText(text + "\n");
            LogBox.ScrollToCaret();
        }
    }
}
