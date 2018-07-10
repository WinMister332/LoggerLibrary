using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LoggerSharp
{
    /// <summary>
    /// The physical file on the current system that log output will be written to.
    /// </summary>
    public class LogFile
    {
        private string logFilePath = "";
        private readonly string dateTime;

        /// <summary>
        /// Creates a new log file.
        /// </summary>
        /// <param name="path">The path of the new log file.</param>
        public LogFile(string path)
        {
            try
            {
                if (Path.GetFileName(path) == "" || Path.GetFullPath(path) == null)
                {
                    //Use default naming convention.
                    dateTime = DateTime.Now.ToString("[HH-mm-ss tt]dd-MM-yyyy");
                    logFilePath += $@"{path}\\{dateTime}.log";
                }
                else
                {
                    //Use custom naming convention and uniary file.
                    if (path.EndsWith(".log"))
                    {
                        logFilePath = path;
                    }
                    else
                    {
                        logFilePath = $@"{path}.log";
                    }
                }

                var dirName = Path.GetDirectoryName(logFilePath);
                DirectoryInfo d = new DirectoryInfo(dirName);
                if (!(d.Exists))
                {
                    if (Logger.GetDebug())
                        LoggerBase.LogInfo(GetType().Name, "Creating LogFile Directory...");
                    d.Create();
                    if (Logger.GetDebug())
                        LoggerBase.LogInfo(GetType().Name, "LogFile Directory Created Successfully.");
                    var fileName = Path.GetFileName(logFilePath);
                    FileInfo f = new FileInfo(fileName);
                    if (!(f.Exists))
                    {
                        if (Logger.GetDebug())
                            LoggerBase.LogInfo(GetType().Name, "Creating LogFile...");
                        f.Create();
                        if (Logger.GetDebug())
                            LoggerBase.LogInfo(GetType().Name, "LogFile Created Successfully.");
                    }

                }
                else
                {
                    var fileName = Path.GetFileName(logFilePath);
                    FileInfo f = new FileInfo(fileName);
                    if (!(f.Exists))
                    {
                        if (Logger.GetDebug())
                            LoggerBase.LogInfo(GetType().Name, "Creating LogFile...");
                        f.Create();
                        if (Logger.GetDebug())
                            LoggerBase.LogInfo(GetType().Name, "LogFile Created Successfully.");
                    }
                }
            }
            catch (Exception ex)
            {
                if (Logger.GetDebug())
                    LoggerBase.LogError(GetType().Name, "Unknown Exception", ex.ToString());
            }
        }

        /// <summary>
        /// Write the specified data to a log file.
        /// </summary>
        /// <param name="data">The data to write to the file.</param>
        public void Write(string data)
        {
            StreamWriter writer = new StreamWriter(logFilePath);
            writer.WriteLine(data);
            writer.Flush();
            writer.Close();
            writer = new StreamWriter(logFilePath);
        }
    }
}
