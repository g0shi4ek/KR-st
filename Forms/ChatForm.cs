using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace KR.Forms
{
    /// <summary>
    /// Variant 11 — main application form.
    ///
    /// Two PCs connected via RS232C null-modem cable:
    ///   • Sender   (Источник)  — uses COM1, selects a text file and sends it chunk by chunk.
    ///   • Receiver (Приёмник)  — uses COM2, receives chunks, shows content live, saves to disk.
    ///
    /// Application-level pace control: the Receiver can request the Sender to slow down,
    /// use normal speed, or speed up at any time during the transfer.
    ///
    /// All data is protected with [7,4] Hamming code (single-bit error correction).
    /// </summary>
    public partial class ChatForm : Form
    {
        // ── Role & port ───────────────────────────────────────────────────────
        private bool       _isSender;
        private SerialPort _port;
        private string     _portName;

        // ── Protocol manager ──────────────────────────────────────────────────
        private readonly Frames _frames = new Frames();

        // ── Sender state ──────────────────────────────────────────────────────
        private string   _fileToSend;
        private byte[]   _fileData;
        private int      _totalChunks;
        private volatile int _currentPaceMs = 100; // default Normal

        // ── Receiver state ────────────────────────────────────────────────────
        private string       _receivedFileName;
        private int          _totalChunksExpected;
        private int          _chunksReceived;
        private readonly Dictionary<int, byte[]> _receivedChunks = new Dictionary<int, byte[]>();

        // ── Connection state ──────────────────────────────────────────────────
        private bool _connected;

        // ─────────────────────────────────────────────────────────────────────
        public ChatForm()
        {
            InitializeComponent();
        }

        // ─────────────────────────────────────────────────────────────────────
        // Form load — show role selection dialog
        // ─────────────────────────────────────────────────────────────────────
        private void ChatForm_Load(object sender, EventArgs e)
        {
            var login = new LoginForm();
            if (login.ShowDialog() != DialogResult.OK)
            {
                Environment.Exit(0);
                return;
            }

            _isSender = login.IsSender;
            _portName = _isSender ? PortSetup.SenderPortName : PortSetup.ReceiverPortName;

            // Configure UI for role
            lblRole.Text    = _isSender ? "Роль: Источник (Sender)" : "Роль: Приёмник (Receiver)";
            lblPortInfo.Text = $"Порт: {_portName}  |  {PortSetup.SettingsDescription}";

            grpSender.Visible   = _isSender;
            grpReceiver.Visible = !_isSender;

            // Wire up Frames events
            _frames.LogBox              = rtbLog;
            _frames.OnConnected        += HandleConnected;
            _frames.OnDisconnected     += HandleDisconnected;
            _frames.OnFileInfoReceived += HandleFileInfoReceived;
            _frames.OnChunkReceived    += HandleChunkReceived;
            _frames.OnTransferComplete += HandleTransferComplete;
            _frames.OnPaceChanged      += HandlePaceChanged;
        }

        // ─────────────────────────────────────────────────────────────────────
        // Connection
        // ─────────────────────────────────────────────────────────────────────
        private void BtnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                _port = PortSetup.OpenPort(_portName);
                _port.DataReceived  += Port_DataReceived;
                _port.ErrorReceived += Port_ErrorReceived;

                AppendLog($"[{DateTime.Now:HH:mm:ss}] Порт {_portName} открыт. Отправка UPLINK...", Color.Cyan);

                if (_isSender)
                {
                    // Sender initiates connection
                    _frames.SendControlFrame(Frames.FrameType.UPLINK, _port);
                }
                // Receiver just listens — it will respond to UPLINK automatically via FrameAction

                btnConnect.Enabled    = false;
                btnDisconnect.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось открыть порт {_portName}:\n{ex.Message}",
                    "Ошибка порта", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDisconnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (_port != null && _port.IsOpen)
                {
                    _frames.SendControlFrame(Frames.FrameType.DOWNLINK, _port);
                    Thread.Sleep(300);
                    _port.DataReceived  -= Port_DataReceived;
                    _port.ErrorReceived -= Port_ErrorReceived;
                    _port.Close();
                    _port.Dispose();
                    _port = null;
                }
            }
            catch { /* ignore on close */ }

            SetDisconnectedState();
            AppendLog($"[{DateTime.Now:HH:mm:ss}] Соединение закрыто.", Color.OrangeRed);
        }

        // ─────────────────────────────────────────────────────────────────────
        // Serial port events
        // ─────────────────────────────────────────────────────────────────────
        private void Port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            var port = (SerialPort)sender;
            try
            {
                // Read exactly one frame start byte, then dispatch.
                // FrameAction itself reads the payload bytes for multi-byte frames
                // (FILE_INFO, CHUNK), so we must NOT loop here while it is running.
                int b = port.ReadByte();
                if (b == 0xFF)
                {
                    int ft = port.ReadByte();
                    if (ft >= 0)
                        _frames.FrameAction((byte)ft, port);
                }
            }
            catch (Exception ex)
            {
                AppendLog($"[{DateTime.Now:HH:mm:ss}] Ошибка чтения порта: {ex.Message}", Color.Crimson);
            }
        }

        private void Port_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {
            AppendLog($"[{DateTime.Now:HH:mm:ss}] Ошибка порта: {e.EventType}", Color.Crimson);
        }

        // ─────────────────────────────────────────────────────────────────────
        // Frames event handlers
        // ─────────────────────────────────────────────────────────────────────
        private void HandleConnected()
        {
            _connected = true;
            SafeInvoke(() =>
            {
                lblStatus.Text      = "● Подключено";
                lblStatus.ForeColor = Color.FromArgb(76, 201, 160);
                lblStatus.BackColor = Color.FromArgb(20, 76, 201, 160);
                if (_isSender)
                {
                    btnSendFile.Enabled = !string.IsNullOrEmpty(_fileToSend);
                }
                AppendLog($"[{DateTime.Now:HH:mm:ss}] Соединение установлено.", Color.FromArgb(76, 201, 160));
            });
        }

        private void HandleDisconnected()
        {
            _connected = false;
            SafeInvoke(SetDisconnectedState);
        }

        private void HandleFileInfoReceived(string fileName, int totalChunks)
        {
            SafeInvoke(() =>
            {
                _receivedFileName    = fileName;
                _totalChunksExpected = totalChunks;
                _chunksReceived      = 0;
                _receivedChunks.Clear();

                txtReceivedFileName.Text = fileName;
                progressBarRecv.Value    = 0;
                lblProgressRecv.Text     = "0 %";
                rtbFileContent.Clear();

                AppendLog($"[{DateTime.Now:HH:mm:ss}] Начало приёма файла \"{fileName}\" ({totalChunks} блоков).", Color.Cyan);
            });
        }

        private void HandleChunkReceived(int chunkIndex, byte[] rawData)
        {
            SafeInvoke(() =>
            {
                _receivedChunks[chunkIndex] = rawData;
                _chunksReceived++;

                // Update progress
                if (_totalChunksExpected > 0)
                {
                    int pct = (int)(100.0 * _chunksReceived / _totalChunksExpected);
                    progressBarRecv.Value = Math.Min(pct, 100);
                    lblProgressRecv.Text  = $"{pct} %";
                }

                // Live preview — try to decode as UTF-8 text
                try
                {
                    string text = Encoding.UTF8.GetString(rawData);
                    rtbFileContent.AppendText(text);
                    rtbFileContent.ScrollToCaret();
                }
                catch { /* binary data — skip text preview */ }
            });
        }

        private void HandleTransferComplete()
        {
            SafeInvoke(() =>
            {
                progressBarRecv.Value = 100;
                lblProgressRecv.Text  = "100 %";
                btnSaveFile.Enabled   = true;
                AppendLog($"[{DateTime.Now:HH:mm:ss}] Передача завершена. Получено {_chunksReceived} блоков.", Color.LightGreen);
                MessageBox.Show($"Файл \"{_receivedFileName}\" успешно принят!\nНажмите «Сохранить» для записи на диск.",
                    "Передача завершена", MessageBoxButtons.OK, MessageBoxIcon.Information);
            });
        }

        private void HandlePaceChanged(Frames.PaceLevel pace)
        {
            _currentPaceMs = (int)pace;
            SafeInvoke(() =>
            {
                string label = pace switch
                {
                    Frames.PaceLevel.Slow => "Медленно (500 мс/блок)",
                    Frames.PaceLevel.Fast => "Быстро (10 мс/блок)",
                    _                     => "Нормально (100 мс/блок)",
                };
                AppendLog($"[{DateTime.Now:HH:mm:ss}] Темп изменён: {label}", Color.DarkOrange);
            });
        }

        // ─────────────────────────────────────────────────────────────────────
        // Sender controls
        // ─────────────────────────────────────────────────────────────────────
        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                _fileToSend      = openFileDialog1.FileName;
                txtFilePath.Text = _fileToSend;
                _fileData        = File.ReadAllBytes(_fileToSend);

                // Show preview
                try
                {
                    string preview = File.ReadAllText(_fileToSend, Encoding.UTF8);
                    rtbFileContent.Text = preview;
                }
                catch
                {
                    rtbFileContent.Text = "[Бинарный файл — предпросмотр недоступен]";
                }

                btnSendFile.Enabled = _connected;
                AppendLog($"[{DateTime.Now:HH:mm:ss}] Файл выбран: {Path.GetFileName(_fileToSend)} ({_fileData.Length} байт)", Color.Cyan);
            }
        }

        private void BtnSendFile_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_fileToSend) || _fileData == null)
            {
                MessageBox.Show("Сначала выберите файл.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!_connected || _port == null || !_port.IsOpen)
            {
                MessageBox.Show("Нет активного соединения.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnSendFile.Enabled = false;
            btnBrowse.Enabled   = false;

            // Run transfer on background thread to keep UI responsive
            var thread = new Thread(SendFileThread) { IsBackground = true };
            thread.Start();
        }

        private void SendFileThread()
        {
            try
            {
                string fileName = Path.GetFileName(_fileToSend);
                _totalChunks = (int)Math.Ceiling((double)_fileData.Length / Frames.CHUNK_SIZE);

                SafeInvoke(() =>
                {
                    progressBar.Value = 0;
                    lblProgress.Text  = "0 %";
                    AppendLog($"[{DateTime.Now:HH:mm:ss}] Отправка FILE_INFO: \"{fileName}\", {_totalChunks} блоков...", Color.Cyan);
                });

                // 1. Send FILE_INFO and wait for ACK_FILE_INFO
                _frames.SendFileInfo(fileName, _totalChunks, _port);

                // Wait for ACK_FILE_INFO (handled by DataReceived → FrameAction)
                Thread.Sleep(500);

                // 2. Send chunks
                bool transferOk = true;
                for (int i = 0; i < _totalChunks; i++)
                {
                    int chunkIdx = i; // capture for lambda
                    int offset   = chunkIdx * Frames.CHUNK_SIZE;
                    int len      = Math.Min(Frames.CHUNK_SIZE, _fileData.Length - offset);
                    var chunk    = new byte[len];
                    Array.Copy(_fileData, offset, chunk, 0, len);

                    bool ok = _frames.SendChunk(chunkIdx, chunk, _port);
                    if (!ok)
                    {
                        int failedIdx = chunkIdx;
                        SafeInvoke(() =>
                            AppendLog($"[{DateTime.Now:HH:mm:ss}] Блок #{failedIdx} не доставлен. Передача прервана.", Color.Crimson));
                        transferOk = false;
                        break;
                    }

                    // Apply pace delay (reads volatile field — safe across threads)
                    int delay = _currentPaceMs;
                    if (delay > 0) Thread.Sleep(delay);

                    int pct = (int)(100.0 * (chunkIdx + 1) / _totalChunks);
                    SafeInvoke(() =>
                    {
                        progressBar.Value = Math.Min(pct, 100);
                        lblProgress.Text  = $"{pct} %";
                    });
                }

                if (!transferOk) return;

                // 3. Send TRANSFER_DONE
                _frames.SendControlFrame(Frames.FrameType.TRANSFER_DONE, _port);

                SafeInvoke(() =>
                {
                    progressBar.Value   = 100;
                    lblProgress.Text    = "100 %";
                    btnSendFile.Enabled = true;
                    btnBrowse.Enabled   = true;
                    AppendLog($"[{DateTime.Now:HH:mm:ss}] Файл отправлен полностью.", Color.LightGreen);
                    MessageBox.Show("Файл успешно отправлен!", "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
                });
            }
            catch (Exception ex)
            {
                SafeInvoke(() =>
                {
                    btnSendFile.Enabled = true;
                    btnBrowse.Enabled   = true;
                    AppendLog($"[{DateTime.Now:HH:mm:ss}] Ошибка передачи: {ex.Message}", Color.Crimson);
                    MessageBox.Show($"Ошибка передачи:\n{ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                });
            }
        }

        private void CmbErrorMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            _frames.TestErrorMode = cmbErrorMode.SelectedIndex switch
            {
                1 => Frames.ErrorMode.OneBit,
                2 => Frames.ErrorMode.TwoBit,
                _ => Frames.ErrorMode.None,
            };
            string desc = cmbErrorMode.SelectedIndex switch
            {
                1 => "⚡ Режим: 1-битовая ошибка (Хэмминг исправит)",
                2 => "💥 Режим: 2-битовая ошибка (передача прервётся)",
                _ => "✅ Режим: без ошибок",
            };
            AppendLog($"[{DateTime.Now:HH:mm:ss}] {desc}", Color.FromArgb(255, 200, 80));
        }

        private void BtnSetPace_Click(object sender, EventArgs e)
        {
            if (!_connected || _port == null || !_port.IsOpen)
            {
                MessageBox.Show("Нет активного соединения.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var pace = IndexToPace(cmbPace.SelectedIndex);
            _frames.SendPace(pace, _port);
            _currentPaceMs = (int)pace;
            AppendLog($"[{DateTime.Now:HH:mm:ss}] Темп задан: {pace} ({_currentPaceMs} мс/блок)", Color.DarkOrange);
        }

        // ─────────────────────────────────────────────────────────────────────
        // Receiver controls
        // ─────────────────────────────────────────────────────────────────────
        private void BtnSetPaceRecv_Click(object sender, EventArgs e)
        {
            if (!_connected || _port == null || !_port.IsOpen)
            {
                MessageBox.Show("Нет активного соединения.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var pace = IndexToPace(cmbPaceRecv.SelectedIndex);
            _frames.SendPace(pace, _port);
            AppendLog($"[{DateTime.Now:HH:mm:ss}] Запрос темпа: {pace}", Color.DarkOrange);
        }

        private void BtnSaveFile_Click(object sender, EventArgs e)
        {
            if (_receivedChunks.Count == 0)
            {
                MessageBox.Show("Нет принятых данных.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            saveFileDialog1.FileName = _receivedFileName ?? "received.txt";
            if (saveFileDialog1.ShowDialog() != DialogResult.OK) return;

            try
            {
                // Assemble chunks in order
                var allData = new List<byte>();
                for (int i = 0; i < _totalChunksExpected; i++)
                {
                    if (_receivedChunks.TryGetValue(i, out byte[] chunk))
                        allData.AddRange(chunk);
                }

                File.WriteAllBytes(saveFileDialog1.FileName, allData.ToArray());
                AppendLog($"[{DateTime.Now:HH:mm:ss}] Файл сохранён: {saveFileDialog1.FileName}", Color.LightGreen);
                MessageBox.Show($"Файл сохранён:\n{saveFileDialog1.FileName}", "Сохранено",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения:\n{ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────────────────────────────────────
        // Menu
        // ─────────────────────────────────────────────────────────────────────
        private void MenuItemHelp_Click(object sender, EventArgs e)
        {
            var form = new CreatorsForm();
            form.Show();
        }

        // ─────────────────────────────────────────────────────────────────────
        // Helpers
        // ─────────────────────────────────────────────────────────────────────
        private void SetDisconnectedState()
        {
            _connected            = false;
            lblStatus.Text        = "● Не подключено";
            lblStatus.ForeColor   = Color.FromArgb(224, 82, 82);
            lblStatus.BackColor   = Color.FromArgb(40, 224, 82, 82);
            btnConnect.Enabled    = true;
            btnDisconnect.Enabled = false;
            btnSendFile.Enabled   = false;
        }

        private static Frames.PaceLevel IndexToPace(int index) => index switch
        {
            0 => Frames.PaceLevel.Slow,
            2 => Frames.PaceLevel.Fast,
            _ => Frames.PaceLevel.Normal,
        };

        private void AppendLog(string text, Color color)
        {
            if (rtbLog.InvokeRequired)
            {
                rtbLog.Invoke(new Action(() => AppendLog(text, color)));
                return;
            }
            rtbLog.SelectionStart  = rtbLog.TextLength;
            rtbLog.SelectionLength = 0;
            rtbLog.SelectionColor  = color;
            rtbLog.AppendText(text + "\n");
            rtbLog.ScrollToCaret();
        }

        private void SafeInvoke(Action action)
        {
            if (IsDisposed) return;
            if (InvokeRequired)
                Invoke(action);
            else
                action();
        }
    }
}
