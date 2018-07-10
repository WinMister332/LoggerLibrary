using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace LoggerSharp
{
    internal static class LoggerBase
    {
        internal static void Log()
        {
            Log(" ");
        }

        internal static void Log(string message, bool write = false)
        {
            if (write)
            {
                Debug.Write(message);
                System.Console.Write(message);
            }
            else
            {
                Debug.WriteLine(message);
                System.Console.WriteLine(message);
            }
        }

        internal static void Log(string sender, int status, string message, bool debug = false, string logFilePath = "")
        {
            LogFile logFile = null;
            if (!(status == -5))
            {
                if (logFilePath != "" || logFilePath != null)
                    logFile = new LogFile(logFilePath);
                if (status == -4 && debug)
                {
                    if (sender != "" && sender != null)
                    {
                        var prevColor = System.Console.ForegroundColor;
                        System.Console.ForegroundColor = ConsoleColor.Cyan;
                        var x = $@"[{DateTime.Now.ToString("HH:mm:ss")}][{sender}][DEBUG][SEVERE]: {message}";
                        Log(x);
                        System.Console.ForegroundColor = prevColor;
                        if (!(logFilePath == null))
                            logFile.Write(x);
                    }
                    else
                    {
                        var prevColor = System.Console.ForegroundColor;
                        System.Console.ForegroundColor = ConsoleColor.Cyan;
                        var x = $@"[{DateTime.Now.ToString("HH:mm:ss")}][DEBUG][SEVERE]: {message}";
                        Log(x);
                        System.Console.ForegroundColor = prevColor;
                        if (!(logFilePath == null))
                            logFile.Write(x);
                    }
                }
                else if (status == -3 && debug)
                {
                    if (sender != "" && sender != null)
                    {
                        var prevColor = System.Console.ForegroundColor;
                        System.Console.ForegroundColor = ConsoleColor.Cyan;
                        var x = $@"[{DateTime.Now.ToString("HH:mm:ss")}][{sender}][DEBUG][ERROR]: {message}";
                        System.Console.ForegroundColor = prevColor;
                        Log(x);
                        if (!(logFilePath == null))
                            logFile.Write(x);
                    }
                    else
                    {
                        var x = $@"[{DateTime.Now.ToString("HH:mm:ss")}][DEBUG][SEVERE]: {message}";
                        Log(x);
                        if (!(logFilePath == null))
                            logFile.Write(x);
                    }
                }
                else if (status == -2 && debug)
                {
                    if (sender != "" && sender != null)
                    {
                        var prevColor = System.Console.ForegroundColor;
                        System.Console.ForegroundColor = ConsoleColor.Cyan;
                        var x = $@"[{DateTime.Now.ToString("HH:mm:ss")}][{sender}][DEBUG][WARNING]: {message}";
                        Log(x);
                        System.Console.ForegroundColor = prevColor;
                        if (!(logFilePath == null))
                            logFile.Write(x);
                    }
                    else
                    {
                        var prevColor = System.Console.ForegroundColor;
                        System.Console.ForegroundColor = ConsoleColor.Cyan;
                        var x = $@"[{DateTime.Now.ToString("HH:mm:ss")}][DEBUG][SEVERE]: {message}";
                        Log(x);
                        System.Console.ForegroundColor = prevColor;
                        if (!(logFilePath == null))
                            logFile.Write(x);
                    }
                }
                else if (status == -1 && debug)
                {
                    if (sender != "" && sender != null)
                    {
                        var prevColor = System.Console.ForegroundColor;
                        System.Console.ForegroundColor = ConsoleColor.Cyan;
                        var x = $@"[{DateTime.Now.ToString("HH:mm:ss")}][{sender}][DEBUG][INFO]: {message}";
                        Log(x);
                        System.Console.ForegroundColor = prevColor;
                        if (!(logFilePath == null))
                            logFile.Write(x);
                    }
                    else
                    {
                        var prevColor = System.Console.ForegroundColor;
                        System.Console.ForegroundColor = ConsoleColor.Cyan;
                        var x = $@"[{DateTime.Now.ToString("HH:mm:ss")}][DEBUG][SEVERE]: {message}";
                        Log(x);
                        System.Console.ForegroundColor = prevColor;
                        if (!(logFilePath == null))
                            logFile.Write(x);
                    }
                }
                else if (status == 0)
                {
                    if (sender != "" && sender != null)
                    {
                        var prevColor = System.Console.ForegroundColor;
                        System.Console.ForegroundColor = ConsoleColor.White;
                        var x = $@"[{DateTime.Now.ToString("HH:mm:ss")}][{sender}][INFO]: {message}";
                        Log(x);
                        System.Console.ForegroundColor = prevColor;
                        if (!(logFilePath == null))
                            logFile.Write(x);
                    }
                    else
                    {
                        var prevColor = System.Console.ForegroundColor;
                        System.Console.ForegroundColor = ConsoleColor.White;
                        var x = $@"[{DateTime.Now.ToString("HH:mm:ss")}][INFO]: {message}";
                        Log(x);
                        System.Console.ForegroundColor = prevColor;
                        if (!(logFilePath == null))
                            logFile.Write(x);
                    }
                }
                else if (status == 1)
                {
                    if (sender != "" && sender != null)
                    {
                        var prevColor = System.Console.ForegroundColor;
                        System.Console.ForegroundColor = ConsoleColor.White;
                        var x = $@"[{DateTime.Now.ToString("HH:mm:ss")}][{sender}][WARNING]: {message}";
                        Log(x);
                        System.Console.ForegroundColor = prevColor;
                        if (!(logFilePath == null))
                            logFile.Write(x);
                    }
                    else
                    {
                        var prevColor = System.Console.ForegroundColor;
                        System.Console.ForegroundColor = ConsoleColor.White;
                        var x = $@"[{DateTime.Now.ToString("HH:mm:ss")}][WARNING]: {message}";
                        Log(x);
                        System.Console.ForegroundColor = prevColor;
                        if (!(logFilePath == null))
                            logFile.Write(x);
                    }
                }
                else if (status == 2)
                {
                    if (sender != "" && sender != null)
                    {
                        var prevColor = System.Console.ForegroundColor;
                        System.Console.ForegroundColor = ConsoleColor.Red;
                        var x = $@"[{DateTime.Now.ToString("HH:mm:ss")}][{sender}][ERROR]: {message}";
                        Log(x);
                        System.Console.ForegroundColor = prevColor;
                        if (!(logFilePath == null))
                            logFile.Write(x);
                    }
                    else
                    {
                        var prevColor = System.Console.ForegroundColor;
                        System.Console.ForegroundColor = ConsoleColor.Red;
                        var x = $@"[{DateTime.Now.ToString("HH:mm:ss")}][ERROR]: {message}";
                        Log(x);
                        System.Console.ForegroundColor = prevColor;
                        if (!(logFilePath == null))
                            logFile.Write(x);
                    }
                }
                else
                {
                    if (sender != "" && sender != null)
                    {
                        var prevColor = System.Console.ForegroundColor;
                        System.Console.ForegroundColor = ConsoleColor.Red;
                        var x = $@"[{DateTime.Now.ToString("HH:mm:ss")}][{sender}][SEVERE]: {message}";
                        Log(x);
                        System.Console.ForegroundColor = prevColor;
                        if (!(logFilePath == null))
                            logFile.Write(x);
                    }
                    else
                    {
                        var prevColor = System.Console.ForegroundColor;
                        System.Console.ForegroundColor = ConsoleColor.Red;
                        var x = $@"[{DateTime.Now.ToString("HH:mm:ss")}][SEVERE]: {message}";
                        Log(x);
                        System.Console.ForegroundColor = prevColor;
                        if (!(logFilePath == null))
                            logFile.Write(x);
                    }
                }
            }
        }

        internal static void Log(string sender, int status, string message, List<string> output, bool debug = false, string logFilePath = "")
        {
            string x = "";
            foreach (string s in output)
            {
                if (x == "" || x == null)
                    x = $@"    - {s}";
                else
                    x = $@"\n    - {x}";
            }
            var mx = $@"{message}: \n {x}";
            Log(sender, status, mx, debug, logFilePath);
        }

        internal static void LogError(string sender, string header, string message)
        {
            if (sender == "" || sender == null)
            {
                Log($@"[LOGGER][ERROR]: {header} -> {message}");
            }
            else
            {
                Log($@"[LOGGER|{sender.ToUpper()}][ERROR]: {header} -> {message}");
            }
        }

        internal static void LogInfo(string sender, string message)
        {
            if (sender == null || sender == "")
            {
                Log($@"[LOGGER]: {message}");
            }
            else
            {
                Log($@"[LOGGER|{sender}]: {message}");
            }
        }
    }
}
