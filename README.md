# LoggerSharp
A simple logging interface designed in C# to be used with .NETStandard based applications including WinForms.

### Implement into application

```CSharp
imports System;
imports System.IO;
imports System.Text;
imports System.Ling;
imports System.Collections.Generic;
imports WMLoggerLibrary;

partial class Program
{
  static void Main(string[] args)
  {
    new Program().Start();
  }
  
  private Logger logger = null;
  
  public Program()
  {
    //The arguments in the logger: bool - for whether the logger allows debug output. string - The path the log files are saved to.
    //Remove the string value for NO log file.
    logger = new Logger(true, new DirectoryInfo($@"{Directory.GetCurrentDirectory()}\Logs"));
  }
  
  public void Start()
  {
    //logger.Log("HelloWorld!"); //Prints a value without tags or status string and is NOT recorded to the log file.
    logger.Log(LogStatus.INFO, "HelloWorld!"); //Prints a value with tags and an INFO status tag.
  }
}
```
#### Logger.Log methods
logger.Log("Hello Word!");
Output:
```
Hello World!
```
logger.Log(LogStatus.INFO, "Hello World!");
```
[12:37:48][LoggerLibrary][INFO] Hello World!
```
logger.Log(LogStatus.INFO, "Hello World!", new string[] {"This", "is", "a", "list!"}.ToList());
```
[12:37:48][LoggerLibrary][INFO] Hello World:
    - This
    - is
    - a
    - list
```
