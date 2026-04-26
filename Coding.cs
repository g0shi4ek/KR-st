using System;
using System.Collections;
using System.Collections.Generic;

namespace KR
{
    /// <summary>
    /// [7,4] Hamming encoder/decoder with single-bit error correction.
    /// Each byte is split into two 4-bit nibbles; each nibble is encoded
    /// into 7 bits → one character becomes 2 bytes (14 used bits, 2 padding).
    /// </summary>
    class Coding
    {
        // ── Cyrillic Win-1251 ↔ Unicode helpers ──────────────────────────────
        private static int UnicodeToWin(int u) => u - 848;
        private static int WinToUnicode(int w) => w + 848;

        // ── Encode a single 4-bit nibble → 7-bit Hamming codeword ────────────
        // Bit positions (0-based, LSB first):
        //   pos 0 = d1, pos 1 = d2, pos 2 = d3, pos 4 = d4  (data bits)
        //   pos 3 = p1, pos 5 = p2, pos 6 = p3              (parity bits)
        private static BitArray EncodeNibble(BitArray d)
        {
            var c = new BitArray(7);
            c[0] = d[0]; // d1
            c[1] = d[1]; // d2
            c[2] = d[2]; // d3
            c[4] = d[3]; // d4
            c[3] = c[0] ^ c[1] ^ c[2];          // p1 covers d1,d2,d3
            c[5] = c[0] ^ c[1] ^ c[4];          // p2 covers d1,d2,d4
            c[6] = c[0] ^ c[2] ^ c[4];          // p3 covers d1,d3,d4
            return c;
        }

        // ── Decode a 7-bit codeword → 4-bit nibble (corrects 1-bit errors) ──
        private static BitArray DecodeNibble(BitArray c)
        {
            // Syndrome
            bool s0 = c[6] ^ c[4] ^ c[2] ^ c[0]; // p3 check
            bool s1 = c[5] ^ c[4] ^ c[1] ^ c[0]; // p2 check
            bool s2 = c[3] ^ c[2] ^ c[1] ^ c[0]; // p1 check

            int errPos = (s0 ? 4 : 0) | (s1 ? 2 : 0) | (s2 ? 1 : 0);
            // errPos is 1-based position of the erroneous bit (0 = no error)
            if (errPos != 0 && errPos <= 7)
            {
                // Flip the erroneous bit (convert 1-based to 0-based index)
                int idx = errPos - 1;
                c[idx] = !c[idx];
            }

            var d = new BitArray(4);
            d[0] = c[0]; // d1
            d[1] = c[1]; // d2
            d[2] = c[2]; // d3
            d[3] = c[4]; // d4
            return d;
        }

        // ── Public API ────────────────────────────────────────────────────────

        /// <summary>
        /// Encode a string to a byte array using [7,4] Hamming.
        /// Each character → 2 bytes (low nibble + high nibble, each 7 bits).
        /// </summary>
        public byte[] Encode(string message)
        {
            if (string.IsNullOrEmpty(message)) return new byte[0];
            var result = new List<byte>();
            foreach (char ch in message)
            {
                int code = ch;
                if (code >= 1040 && code <= 1103) code = UnicodeToWin(code);

                var low  = new BitArray(4);
                var high = new BitArray(4);
                for (int i = 0; i < 4; i++) low[i]  = ((code >> i)     & 1) == 1;
                for (int i = 0; i < 4; i++) high[i] = ((code >> (i+4)) & 1) == 1;

                var codedLow  = EncodeNibble(low);
                var codedHigh = EncodeNibble(high);

                // Pack into 2 bytes: bits 0-6 = low nibble codeword, bits 7-13 = high nibble codeword
                var packed = new BitArray(16);
                for (int i = 0; i < 7; i++) packed[i]   = codedLow[i];
                for (int i = 0; i < 7; i++) packed[i+7] = codedHigh[i];
                packed[14] = false;
                packed[15] = false;

                var bytes = new byte[2];
                packed.CopyTo(bytes, 0);
                result.Add(bytes[0]);
                result.Add(bytes[1]);
            }
            return result.ToArray();
        }

        /// <summary>
        /// Encode a raw byte array (binary file data) using [7,4] Hamming.
        /// Each byte → 2 bytes.
        /// </summary>
        public byte[] EncodeBytes(byte[] data)
        {
            if (data == null || data.Length == 0) return new byte[0];
            var result = new List<byte>();
            foreach (byte b in data)
            {
                var low  = new BitArray(4);
                var high = new BitArray(4);
                for (int i = 0; i < 4; i++) low[i]  = ((b >> i)     & 1) == 1;
                for (int i = 0; i < 4; i++) high[i] = ((b >> (i+4)) & 1) == 1;

                var codedLow  = EncodeNibble(low);
                var codedHigh = EncodeNibble(high);

                var packed = new BitArray(16);
                for (int i = 0; i < 7; i++) packed[i]   = codedLow[i];
                for (int i = 0; i < 7; i++) packed[i+7] = codedHigh[i];
                packed[14] = false;
                packed[15] = false;

                var bytes = new byte[2];
                packed.CopyTo(bytes, 0);
                result.Add(bytes[0]);
                result.Add(bytes[1]);
            }
            return result.ToArray();
        }

        /// <summary>
        /// Decode a byte array encoded with [7,4] Hamming back to a string.
        /// Returns null if the data length is invalid.
        /// </summary>
        public string Decode(byte[] message)
        {
            if (message == null || message.Length % 2 != 0) return null;
            var result = new System.Text.StringBuilder();
            for (int i = 0; i < message.Length; i += 2)
            {
                var packed = new BitArray(new byte[] { message[i], message[i+1] });
                var codedLow  = new BitArray(7);
                var codedHigh = new BitArray(7);
                for (int j = 0; j < 7; j++) codedLow[j]  = packed[j];
                for (int j = 0; j < 7; j++) codedHigh[j] = packed[j+7];

                var low  = DecodeNibble(codedLow);
                var high = DecodeNibble(codedHigh);

                int code = 0;
                for (int j = 0; j < 4; j++) if (low[j])  code |= (1 << j);
                for (int j = 0; j < 4; j++) if (high[j]) code |= (1 << (j+4));

                if (code >= 192 && code <= 255) code = WinToUnicode(code);
                result.Append((char)code);
            }
            return result.ToString();
        }

        /// <summary>
        /// Decode a byte array encoded with [7,4] Hamming back to raw bytes.
        /// Returns null if the data length is invalid.
        /// </summary>
        public byte[] DecodeBytes(byte[] message)
        {
            if (message == null || message.Length % 2 != 0) return null;
            var result = new List<byte>();
            for (int i = 0; i < message.Length; i += 2)
            {
                var packed = new BitArray(new byte[] { message[i], message[i+1] });
                var codedLow  = new BitArray(7);
                var codedHigh = new BitArray(7);
                for (int j = 0; j < 7; j++) codedLow[j]  = packed[j];
                for (int j = 0; j < 7; j++) codedHigh[j] = packed[j+7];

                var low  = DecodeNibble(codedLow);
                var high = DecodeNibble(codedHigh);

                int code = 0;
                for (int j = 0; j < 4; j++) if (low[j])  code |= (1 << j);
                for (int j = 0; j < 4; j++) if (high[j]) code |= (1 << (j+4));

                result.Add((byte)(code & 0xFF));
            }
            return result.ToArray();
        }
    }
}
