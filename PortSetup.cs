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
        public const int    DefaultBaudRate  = 9600;
        public const int    DefaultDataBits  = 8;
        public const Parity DefaultParity    = Parity.None;
        public const StopBits DefaultStopBits = StopBits.One;

        // Port names
        public const string SenderPortName   = "COM1";
        public const string ReceiverPortName = "COM2";

        /// <summary>
        /// Opens and returns a configured SerialPort for the given role.
        /// Throws an exception if the port cannot be opened.
        /// </summary>
        public static SerialPort OpenPort(string portName)
        {
            var port = new SerialPort(portName, DefaultBaudRate, DefaultParity, DefaultDataBits, DefaultStopBits)
            {
                RtsEnable    = true,
                DtrEnable    = true,
                ReadTimeout  = 2000,
                WriteTimeout = 2000
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
