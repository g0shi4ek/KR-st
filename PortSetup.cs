using System;
using System.IO.Ports;

namespace KR
{
    /// <summary>
    /// Variant 11: 2 PCs connected via RS232C null-modem cable.
    /// COM port parameters are fixed by default (9600, 8, None, One).
    /// The Sender uses COM1, the Receiver uses COM2.
    /// </summary>
    class PortSetup
    {
        // Default COM-port parameters (fixed per task specification)
        public const int      DefaultBaudRate  = 9600;
        public const int      DefaultDataBits  = 8;
        public const Parity   DefaultParity    = Parity.None;
        public const StopBits DefaultStopBits  = StopBits.One;

        // Port names
        public const string SenderPortName   = "COM1";
        public const string ReceiverPortName = "COM2";

        /// <summary>
        /// Normalises a port name so that it works with com0com virtual ports.
        /// For COM ports, .NET's SerialPort accepts "COM1" etc., but some drivers
        /// (including com0com) require the full device path "\\.\COM1".
        /// We always pass the full path to avoid "Could not find file" errors.
        /// </summary>
        private static string NormalisePortName(string portName)
        {
            // Already in device-path form
            if (portName.StartsWith(@"\\.\", StringComparison.OrdinalIgnoreCase))
                return portName;

            return @"\\.\" + portName;
        }

        /// <summary>
        /// Opens and returns a configured SerialPort for the given role.
        /// Throws an exception if the port cannot be opened.
        /// </summary>
        public static SerialPort OpenPort(string portName)
        {
            string devicePath = NormalisePortName(portName);

            var port = new SerialPort(devicePath, DefaultBaudRate, DefaultParity, DefaultDataBits, DefaultStopBits)
            {
                RtsEnable    = true,
                DtrEnable    = true,
                ReadTimeout  = 5000,
                WriteTimeout = 5000
            };
            port.Open();
            return port;
        }

        /// <summary>
        /// Returns a description string of the default port settings.
        /// </summary>
        public static string SettingsDescription =>
            $"{DefaultBaudRate} bps, {DefaultDataBits} data bits, " +
            $"Parity: {DefaultParity}, Stop bits: {DefaultStopBits}";
    }
}
