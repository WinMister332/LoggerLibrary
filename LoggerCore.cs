using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMLoggerLibrary
{
    public class LoggerCore
    {
        private bool allowDebug;
        private LogFile LF = null;
        private ConsoleColor originalColor = ConsoleColor.White;
        public LoggerCore(bool debug, FileInfo logFile)
        {
            allowDebug = debug;
            if (logFile != null)
                LF = new LogFile(logFile);
        }

        public LoggerCore(bool debug, DirectoryInfo logFileDirectory)
        {
            allowDebug = true;
            if (logFileDirectory != null)
                LF = new LogFile(logFileDirectory);
        }

        public void Log(string message)
        {
            Console.WriteLine(message);
        }

        public void Log(string sender, int status, string message)
        {
            var origCol = Console.ForegroundColor;
            Console.ForegroundColor = GetStatusColor(status);
            XLog(sender, status, message);
            Console.ForegroundColor = origCol;
        }

        private void XLog(string sender, int status, string message)
        {
            var time = DateTime.Now.ToString("HH:mm:ss");
            var origColor = Console.ForegroundColor;
            if (allowDebug == true)
            {
                if (status < 0)
                {
                    //Debug
                    string data = $@"[{time}][{sender}]{GetStatusTag(status)} {message}";
                    Log(data);
                    if (!(LF == null)) LF.Write(data);
                }
                else if (status == -5) { }
                else
                {
                    string data = $@"[{time}][{sender}]{GetStatusTag(status)} {message}";
                    Log(data);
                    if (!(LF == null)) LF.Write(data);
                }
            }
            else
            {
                if (status > 0)
                {
                    string data = $@"[{DateTime.Now.ToString("HH:mm:ss")}][{sender}]{GetStatusTag(status)} {message}";
                    Log(data);
                    if (!(LF == null)) LF.Write(data);
                }
                else if (status == -5) { }
            }
        }

        public void Log(string sender, int status, string message, ConsoleColor color)
        {
            originalColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            XLog(sender, status, message);
            Console.ForegroundColor = originalColor;
        }

        public void Log(string sender, int status, string message, List<string> data)
        {
            string x = "";
            foreach (string s in data)
            {
                if (x == "")
                    x = $@"    - {s}";
                else
                    x += $@"\n    - {s}";
            }
            XLog(sender, status, $@"{message}\n{x}");
        }

        public void Log(string sender, int status, string message, List<string> data, ConsoleColor color)
        {
            originalColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Log(sender, status, message, data);
            Console.ForegroundColor = originalColor;
        }

        private string GetStatusTag(int status)
        {
            string output = "";
            switch (status)
            {
                case 0: output = "[INFO]"; break;
                case 1: output = "[WARNING]"; break;
                case 2: output = "[ERROR]"; break;
                case 3: output = "[SEVERE]"; break;
                case -1: output = "[DEBUG][INFO]"; break;
                case -2: output = "[DEBUG][WARNING]"; break;
                case -3: output = "[DEBUG][ERROR]"; break;
                case -4: output = "[DEBUG][SEVERE]"; break;
            }
            return output;
        }
        private ConsoleColor GetStatusColor(int status)
        {
            ConsoleColor color = ConsoleColor.White;
            switch (status)
            {
                case 0: color = ConsoleColor.White; break;
                case 1: color = ConsoleColor.Yellow; break;
                case 2: color = ConsoleColor.DarkYellow; break;
                case 3: color = ConsoleColor.Red; break;
                case -1: color = ConsoleColor.DarkCyan; break;
                case -2: color = ConsoleColor.DarkCyan; break;
                case -3: color = ConsoleColor.DarkCyan; break;
                case -4: color = ConsoleColor.DarkCyan; break;
            }
            return color;
        }
    }
}
