# LoggerSharp
A simple logger class that was built in C# for a various number of applications.

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
[![NuGet](https://img.shields.io/nuget/v/Nuget.Core.svg?style=for-the-badge)](https://www.nuget.org/packages/LoggerSharp/1.0.5)
[![NuGet Downloads](https://img.shields.io/nuget/dt/Microsoft.AspNetCore.Mvc.svg?style=for-the-badge)](https://www.nuget.org/stats/packages/LoggerSharp?groupby=Version)
[![Pull Requests](https://img.shields.io/github/issues-pr/cdnjs/cdnjs.svg?style=for-the-badge)](https://github.com/WinMister332/LoggerSharp/pulls)
[![GitHub issues](https://img.shields.io/github/issues/badges/shields.svg?style=for-the-badge)](https://github.com/WinMister332/LoggerSharp/issues)
[![GitHub forks](https://img.shields.io/github/forks/badges/shields.svg?style=for-the-badge&label=Fork)](https://github.com/WinMister332/LoggerSharp/network/members)

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
