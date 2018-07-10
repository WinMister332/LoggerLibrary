using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LoggerSharp
{
    /// <summary>
    /// A simple class expanding apon the Logger class, for beginers or anyone who doesn't know the correct numerical status IDs.
    /// </summary>
    public sealed class LoggerSharp
    {
        private Logger logger;

        /// <summary>
        /// Creates a new instance of the <see cref="LoggerSharp"> class and forwards all the specified information to the parent <see cref="Logger">, <see cref="LoggerBase">, and <see cref="LogFile"> classes.
        /// </summary>
        /// <param name="sender">The sender or name to display in the console and <see cref="LogFile"></param>
        /// <param name="location">The <see cref="LogLocation"> and system path to the log file, or a directory to store default-named <see cref="LogFile">.</param>
        /// <param name="debug">Allow use of the debug status in the console and the <see cref="LogFile"></param>
        public LoggerSharp(string sender, LogLocation location, bool debug)
        {
            logger = new Logger(sender, location.location, debug);
        }

        /// <summary>
        /// Creates a new instance of the <see cref="LoggerSharp"> class and forwards all the specified information to the parent <see cref="Logger">, <see cref="LoggerBase">, and <see cref="LogFile"> classes.
        /// </summary>
        /// <param name="sender">The sender or name to display in the console and <see cref="LogFile"></param>
        /// <param name="location">The <see cref="LogLocation"> and system path to the log file, or a directory to store default-named <see cref="LogFile">.</param>
        /// <param name="debug">Allow use of the debug status in the console and the <see cref="LogFile"></param>
        public LoggerSharp(object sender, LogLocation location, bool debug)
        {
            logger = new Logger(sender.GetType().Name, location.location, debug);
        }

        /// <summary>
        /// Prints a blank line to the console.
        /// </summary>
        public void Log()
        {
            logger.Log();
        }

        /// <summary>
        /// Prints a message to the console.
        /// </summary>
        /// <param name="message">The message to print to the console.</param>
        public void Log(string message)
        {
            logger.Log(message);
        }

        /// <summary>
        /// Prints a status-based message to the console and <see cref="LogFile">.
        /// FORMAT: [12:37:15][Logger][INFO]: This message was outputted.
        /// </summary>
        /// <param name="status">The <see cref="LogStatus"> to display in the console and <see cref="LogFile"> when a message is printed.</param>
        /// <param name="message">The message to print.</param>
        public void Log(LogStatus status, string message)
        {
            int statusID = (int)status;
            logger.Log(statusID, message);
        }

        /// <summary>
        /// Prints a status-based message and the specified output to the console and <see cref="LogFile">.
        /// </summary>
        /// <param name="status">The <see cref="LogStatus"> to print to the console and <see cref="LogFile">.</param>
        /// <param name="message">The message to print in the console and <see cref="LogFile">.</param>
        /// <param name="output">The list to output.</param>
        public void Log(LogStatus status, string message, List<string> output)
        {
            int statusID = (int)status;
            logger.Log(statusID, message, output);
        }

        /// <summary>
        /// The location of a custom log file, or the location of a directory to store log files with date-based names.
        /// </summary>
        public class LogLocation
        {
            internal string location = "";

            /// <summary>
            /// The path to store default log files.
            /// </summary>
            /// <param name="logFileDirectory">The directory the default log files will be stored to.</param>
            public LogLocation(DirectoryInfo logFileDirectory)
            {
                location = logFileDirectory.FullName;
            }

            /// <summary>
            /// The file containing the location, this will be the ONLY log file generated.
            /// </summary>
            /// <param name="file">The file with a custom name and extention.</param>
            public LogLocation(FileInfo file)
            {
                location = file.FullName;
            }

            /// <summary>
            /// The directory and file, this will be the ONLY log file generated.
            /// </summary>
            /// <param name="directory">The directory the log file will be stored to</param>
            /// <param name="file">The log file with the custom name and extention the logger will use.</param>
            public LogLocation(DirectoryInfo directory, FileInfo file)
            {
                location = $@"{directory.FullName}{Path.DirectorySeparatorChar}{file.FullName}";
            }
        }
    }
}
