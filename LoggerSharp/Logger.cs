using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;

namespace LoggerSharp
{

    /// <summary>
    /// The main Logger class. For a more simple logger, please use the <see cref="LoggerSharp"> class.
    /// </summary>
    public class Logger
    {
        private static string _sender = "";
        private static string _logFilePath = "";
        private static bool _debug = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="Logger"> class and utilizes methods from <see cref="LoggerBase"> that allow console and file printing.
        /// </summary>
        /// <param name="sender">The sender or name to display in the log.</param>
        /// <param name="logFilePath">The log file path. If null or empty no logfile will be created.</param>
        /// <param name="debug">Allow use of the debug status.</param>
        public Logger(string sender, string logFilePath = "", bool debug = false)
        {
            _sender = sender;
            _logFilePath = logFilePath;
            _debug = debug;
        }

        /// <summary>
        /// Logs a blank to the console, but not the <see cref="LogFile">.
        /// </summary>
        public void Log()
        {
            LoggerBase.Log();
        }

        /// <summary>
        /// Logs a message to the console, but not the <see cref="LogFile">.
        /// </summary>
        /// <param name="message">The message to print to the console.</param>
        public void Log(string message)
        {
            LoggerBase.Log(message);
        }

        /// <summary>
        /// Logs a status-based message to the console and the <see cref="LogFile"> if one is found.
        /// </summary>
        /// <param name="status">The status to output.</param>
        /// <param name="message">The message to output.</param>
        public void Log(int status, string message)
        {
            LoggerBase.Log(_sender, status, message, _debug, _logFilePath);
        }

        /// <summary>
        /// Logs a status based message and a list, to the console and to a <see cref="LogFile"> if one is found.
        /// </summary>
        /// <param name="status">The status to print to the console and <see cref="LogFile">.</param>
        /// <param name="message">The message to print to the console and <see cref="LogFile">.</param>
        /// <param name="output">The list to print to the console and <see cref="LogFile">.</param>
        public void Log(int status, string message, List<string> output)
        {
            LoggerBase.Log(_sender, status, message, output, _debug, _logFilePath);
        }

        internal static bool GetDebug()
        {
            return _debug;
        }
    } 
}

namespace LoggerSharp
{
    public class LoggerSharpDebug
    {
        public static void Main(string[] args)
        {

        }
    }
}