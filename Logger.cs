using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMLoggerLibrary
{
    public sealed class Logger
    {
        private LoggerCore core = null;
        private string sender = "";
        public Logger(string sender, bool allowDebug = false, FileInfo logFile = null)
        {
            this.sender = sender;
            core = new LoggerCore(allowDebug, logFile);
        }

        public Logger(string sender, bool allowDebug = false, DirectoryInfo logFileDirectory = null)
        {
            this.sender = sender;
            core = new LoggerCore(allowDebug, logFileDirectory);
        }

        public void Log(string message)
        {
            core.Log(message);
        }

        public void Log(LogStatus status, string message)
        {
            core.Log(sender, GetStatus(status), message);
        }

        public void Log(LogStatus status, string message, ConsoleColor color)
        {
            core.Log(sender, GetStatus(status), message, color);
        }

        public void Log(LogStatus status, string message, List<string> data)
        {
            core.Log(sender, GetStatus(status), message, data);
        }

        public void Log(LogStatus status, string message, List<string> data, ConsoleColor color)
        {
            core.Log(sender, GetStatus(status), message, data, color);
        }

        private int GetStatus(LogStatus status)
        {
            int output = 0;
            switch (status)
            {
                case (LogStatus.INFO): output = 0; break;
                case (LogStatus.WARNING): output = 1; break;
                case (LogStatus.ERROR): output = 2; break;
                case (LogStatus.SEVERE): output = 3; break;
                case (LogStatus.DEBUG_INFO): output = -1; break;
                case (LogStatus.DEBUG_WARNING): output = -2; break;
                case (LogStatus.DEBUG_ERROR): output = -3; break;
                case (LogStatus.DEBUG_SEVERE): output = -4; break;
                case (LogStatus.OFF): output = -5; break;
            }
            return output;
        }

        public void SetSender(string sender)
        {
            this.sender = sender;
        }
    }

    public enum LogStatus
    {
        OFF, INFO, WARNING, ERROR, SEVERE, DEBUG_INFO, DEBUG_WARNING, DEBUG_ERROR, DEBUG_SEVERE
    }
}
