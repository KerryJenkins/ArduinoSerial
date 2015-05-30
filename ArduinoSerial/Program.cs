using System;
using System.IO.Ports;

namespace ArduinoSerial
{
    class Program
    {
        private static SerialPort _arduinoBoard;
        static void Main(string[] args)
        {
            _arduinoBoard = new SerialPort();
            OpenArduinoConnection();
            var command = string.Empty;
            var exit = false;
            do
            {
                command = Console.ReadLine();
                if (command == "exit")
                {
                    exit = true;
                }
                else
                {
                    _arduinoBoard.Write(command);
                }
            }
            while (exit == false);

            CloseArduinoConnection();
        }

        /// <summary>
        /// Closes the connection to an Arduino Board.
        /// </summary>
        public static void CloseArduinoConnection()
        {
            _arduinoBoard.Close();
        }
        /// <summary>
        /// Opens the connection to an Arduino board
        /// </summary>
        public static void OpenArduinoConnection()
        {
            if (!_arduinoBoard.IsOpen)
            {
                _arduinoBoard.DataReceived += arduinoBoard_DataReceived;
                _arduinoBoard.BaudRate = 9600;
                _arduinoBoard.PortName = "COM3";
                _arduinoBoard.Open();
                //arduinoBoard.Write("turn on 13");
            }
            else
            {
                throw new InvalidOperationException("The Serial Port is already open!");
            }
        }
        /// <summary>
        /// Reads weather data from the arduinoBoard serial port
        /// </summary>
        static void arduinoBoard_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            var data = _arduinoBoard.ReadLine();
            Console.WriteLine(data);
        }
    }

}
