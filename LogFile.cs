using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMLoggerLibrary
{
    public class LogFile
    {
        private FileInfo file;
        private readonly string timeStamp;

        public LogFile(FileInfo info)
        {
            //Check the directory, then check the file.
            //If neither exists, create them.
            if (info.Directory.Exists)
            {
                //Check for file.
                if (info.Exists)
                {
                    file = info;
                    Write("\n");
                    if (!Read().Contains($"-=-=-=-=-=-=-=| {DateTime.Now.ToString("yyyy-dd-MM")} |=-=-=-=-=-=-=-"))
                        Write($"-=-=-=-=-=-=-=| {DateTime.Now.ToString("yyyy-dd-MM")} |=-=-=-=-=-=-=-");
                }
                else
                {
                    try
                    {
                        info.Create().Close();
                        file = info;
                        if (!Read().Contains($"-=-=-=-=-=-=-=| {DateTime.Now.ToString("yyyy-dd-MM")} |=-=-=-=-=-=-=-"))
                            Write($"-=-=-=-=-=-=-=| {DateTime.Now.ToString("yyyy-dd-MM")} |=-=-=-=-=-=-=-");
                    }
                    catch (Exception ex) { System.Diagnostics.Debug.WriteLine($"{DateTime.Now.ToString("HH:mm:ss")}: {ex.ToString()}"); }
                }
            }
            else
            {
                try
                {
                    //Create directory.
                    info.Create().Close();
                    //Check for file.
                    if (info.Exists)
                    {
                        file = info;
                        Write("\n");
                        if (!Read().Contains($"-=-=-=-=-=-=-=| {DateTime.Now.ToString("yyyy-dd-MM")} |=-=-=-=-=-=-=-"))
                            Write($"-=-=-=-=-=-=-=| {DateTime.Now.ToString("yyyy-dd-MM")} |=-=-=-=-=-=-=-");
                    }
                    else
                    {
                        try
                        {
                            info.Create().Close();
                            file = info;
                            if (!Read().Contains($"-=-=-=-=-=-=-=| {DateTime.Now.ToString("yyyy-dd-MM")} |=-=-=-=-=-=-=-"))
                                Write($"-=-=-=-=-=-=-=| {DateTime.Now.ToString("yyyy-dd-MM")} |=-=-=-=-=-=-=-");
                        }
                        catch (Exception ex) { System.Diagnostics.Debug.WriteLine($"{DateTime.Now.ToString("HH:mm:ss")}: {ex.ToString()}"); }
                    }
                }
                catch (Exception ex) { System.Diagnostics.Debug.WriteLine($"{DateTime.Now.ToString("HH:mm:ss")}: {ex.ToString()}"); }
            }
        }

        public LogFile(DirectoryInfo info)
        {
            timeStamp = DateTime.Now.ToString("HH:mm:ss(yyyy-dd-MM)");
            if (!info.Exists)
            {
                try
                {
                    info.Create();
                    var f = new FileInfo($@"{info.FullName}\{timeStamp}.log");
                    if (!f.Exists)
                    {
                        try
                        {
                            f.Create().Close();
                            file = f;
                            Write("\n");
                        }
                        catch (Exception ex) { System.Diagnostics.Debug.WriteLine($"{DateTime.Now.ToString("HH:mm:ss")}: {ex.ToString()}"); }
                    }
                    else file = f;
                }
                catch (Exception ex) { System.Diagnostics.Debug.WriteLine($"{DateTime.Now.ToString("HH:mm:ss")}: {ex.ToString()}"); }
            }
            else
            {
                var f = new FileInfo($@"{info.FullName}\{timeStamp}.log");
                if (!f.Exists)
                {
                    try
                    {
                        f.Create().Close();
                        file = f;
                        Write("\n");
                    }
                    catch (Exception ex) { System.Diagnostics.Debug.WriteLine($"{DateTime.Now.ToString("HH:mm:ss")}: {ex.ToString()}"); }
                }
                else file = f;
            }
        }

        public void Write(String text)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(file.FullName, true))
                {
                    sw.WriteLine(text);
                    sw.Flush();
                    sw.Close();
                }
            }
            catch { }
        }
        private string Read()
        {
            string output = "";
            try
            {
                StreamReader sr = new StreamReader(file.FullName);
                output = sr.ReadToEnd();
                sr.Close();
                if (sr == null) sr = new StreamReader(file.FullName);
            }
            catch { }
            return output;
        }
    }
}
