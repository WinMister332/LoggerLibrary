# LoggerSharp
A simple logging interface designed in C# to be used with .NETStandard based applications including WinForms.

[![NuGet Downloads](https://img.shields.io/nuget/dt/LoggerSharp.svg?style=for-the-badge)](https://www.nuget.org/packages/LoggerSharp/)
[![NuGet](https://img.shields.io/nuget/v/LoggerSharp.svg?style=for-the-badge)](https://www.nuget.org/packages/LoggerSharp/)
[![Github issues](https://img.shields.io/github/issues/winmister332/loggersharp.svg?style=for-the-badge)](https://github.com/WinMister332/LoggerSharp/issues)
[![Github forks](https://img.shields.io/github/forks/winmister332/loggersharp.svg?style=for-the-badge&label=Forks)](https://github.com/WinMister332/LoggerSharp/network/members)
[![GitHub top language](https://img.shields.io/github/languages/top/winmister332/loggersharp.svg?style=for-the-badge)](https://github.com/WinMister332/LoggerSharp/search?l=c%23)

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
