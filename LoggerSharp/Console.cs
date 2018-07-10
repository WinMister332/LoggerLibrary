using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace LoggerSharp
{
    /// <summary>
    /// Methods for writing/managing output and input to/from the console.
    /// </summary>
    public class Console
    {
        /// <summary>
        /// The width of the console window.
        /// </summary>
        public static int Width
        {
            get => System.Console.WindowWidth;
            set => System.Console.WindowWidth = value;
        }
        /// <summary>
        /// The height of the console window.
        /// </summary>
        public static int Height
        {
            get => System.Console.WindowHeight;
            set => System.Console.WindowHeight = value;
        }
        /// <summary>
        /// The top or y location of the console window.
        /// </summary>
        public static int Top
        {
            get => System.Console.WindowTop;
            set => System.Console.WindowTop = value;
        }
        /// <summary>
        /// The left or x location of the console window.
        /// </summary>
        public static int Left
        {
            get => System.Console.WindowLeft;
            set => System.Console.WindowLeft = value;
        }
        /// <summary>
        /// The title to display in the console window.
        /// </summary>
        public static string Title
        {
            get => System.Console.Title;
            set => System.Console.Title = value;
        }
        /// <summary>
        /// Write text to the console.
        /// </summary>
        /// <param name="message">The message to print to the console.</param>
        public static void Write(string message)
        {
            LoggerBase.Log(message, true);
        }
        /// <summary>
        /// Writes a line of text to the console.
        /// </summary>
        /// <param name="message">The message to write to the console.</param>
        public static void WriteLine(string message)
        {
            LoggerBase.Log(message);
        }
        /// <summary>
        /// Returns an empty line in the console.
        /// </summary>
        public static void WriteLine()
        {
            WriteLine("");
        }
        /// <summary>
        /// Read the current line of input that was typed.
        /// </summary>
        /// <returns>Text typed into the console.</returns>
        public static string ReadLine()
        {
            return System.Console.ReadLine();
        }
        /// <summary>
        /// Reads all lines of text from the console. (Not Tested.)
        /// </summary>
        /// <returns>All lines of text from the consle in an array.</returns>
        public static string[] ReadAllLines()
        {
            List<string> lines = new List<string>();
            var x = System.Console.OpenStandardOutput();
            var sr = new StreamReader(x);
            var _x = sr.ReadToEnd();
            var _x_ = Regex.Split(_x, Environment.NewLine);
            foreach (string s in _x_)
            {
                lines.Add(s);
            }
            return lines.ToArray();
        }
        /// <summary>
        /// The key that was currently pressed while the console was in-focus.
        /// </summary>
        /// <param name="intercept">Whether the check is intersepted.</param>
        /// <returns>The key that was pressed.</returns>
        public static ConsoleKeyInfo ReadKey(bool intercept = true)
        {
            return System.Console.ReadKey(intercept);
        }
        /// <summary>
        /// The stream that reads data that was inputed by the user.
        /// </summary>
        /// <returns>Input typed by user as stream.</returns>
        public static Stream InputStream()
        {
            return System.Console.OpenStandardInput();
        }
        /// <summary>
        /// The stream that writes the data or messages to the console.
        /// </summary>
        /// <returns>Output from the console window.</returns>
        public static Stream OutputStream()
        {
            return System.Console.OpenStandardOutput();
        }
        /// <summary>
        /// Sets the console forecolor to the specified color.
        /// </summary>
        /// <param name="color">The color to use.</param>
        public static void SetForeColor(ConsoleColor color)
        {
            System.Console.ForegroundColor = color;
        }
        /// <summary>
        /// Sets the console backcolor to the specified color.
        /// </summary>
        /// <param name="color">The color to use.</param>
        /// <param name="refresh">Whether the window should be cleared so the color can be applied evenly throughout the console.</param>
        public static void SetBackColor(ConsoleColor color, bool refresh = false)
        {
            System.Console.BackgroundColor = color;
            if (refresh)
                System.Console.Clear();
        }
        /// <summary>
        /// Gets the current Foreground color of the console.
        /// </summary>
        /// <returns>The color of the console text.</returns>
        public static ConsoleColor GetForeColor()
        {
            return System.Console.ForegroundColor;
        }
        /// <summary>
        /// Gets the current Background color of the console.
        /// </summary>
        /// <returns>The color of the console backdrop.</returns>
        public static ConsoleColor GetBackColor()
        {
            return System.Console.BackgroundColor;
        }
        public static void WriteAt(string s, int x, int y)
        {
            var top = System.Console.CursorTop;
            var left = System.Console.CursorLeft;
            try
            {
                System.Console.SetCursorPosition(left + x, top + y);
                Console.Write(s);
            }
            catch (ArgumentOutOfRangeException e)
            {
                LoggerBase.LogError("", "Argument Out of Range", e.ToString());
            }
        }
        /// <summary>
        /// Processes input and returns true if the input met the specified input result.
        /// </summary>
        /// <param name="text">The text to display next to the input.</param>
        /// <param name="result">The result the input will be compared with.</param>
        /// <param name="hideInput">If true the input will be hidden from the console.</param>
        /// <returns>If the input met the result.</returns>
        public bool ProcessInput(string text, string result, bool hideInput = false)
        {
            if (hideInput)
            {
                if (text.EndsWith(" "))
                    Write(text);
                else
                    Write($"{text} ");
                var input = new KeyInput();
                input.ProcessInput();
                WriteLine();
                if (input.ToString() == result)
                    return true;
            }
            else
            {
                if (text.EndsWith(" "))
                    Write(text);
                else
                    Write(text + " ");
                var input = ReadLine();
                if (input == result) return true;
            }
            return false;
        }
        internal class KeyInput
        {
            private string x = "";

            public void ProcessInput()
            {
                while (true)
                {
                    var key = System.Console.ReadKey(true);
                    if (key.Key == ConsoleKey.Enter)
                    {
                        break;
                    }
                    else if (key.Key == ConsoleKey.Backspace)
                    {
                        if (x.Length == 1)
                        {
                            x = "";
                        }
                        else if (x.Length > 1)
                        {
                            x = x.Remove(x.Length - 1);
                        }
                    }
                    if (!(key.KeyChar.ToString() == "" || key.KeyChar.ToString() == null))
                        if (ValidChar(key.KeyChar))
                            x += key.KeyChar;
                }
            }

            public override string ToString()
            {
                if (x == null || x == "")
                {
                    return "";
                }
                else
                {
                    return x;
                }
            }

            private bool ValidChar(char c)
            {
                if ((!(CharTypes.IsWhitespace(c))) || CharTypes.IsLetter(c) || CharTypes.IsNumeral(c) || CharTypes.IsPunctuation(c) || CharTypes.IsSymbol(c))
                    return true;
                return false;
            }

            private class CharTypes
            {
                public static bool IsLetter(char c)
                {
                    if (c == 'A' || c == 'a')
                        return true;
                    else if (c == 'B' || c == 'b')
                        return true;
                    else if (c == 'C' || c == 'c')
                        return true;
                    else if (c == 'D' || c == 'd')
                        return true;
                    else if (c == 'E' || c == 'e')
                        return true;
                    else if (c == 'F' || c == 'F')
                        return true;
                    else if (c == 'G' || c == 'g')
                        return true;
                    else if (c == 'H' || c == 'h')
                        return true;
                    else if (c == 'I' || c == 'i')
                        return true;
                    else if (c == 'J' || c == 'j')
                        return true;
                    else if (c == 'K' || c == 'k')
                        return true;
                    else if (c == 'L' || c == 'l')
                        return true;
                    else if (c == 'M' || c == 'm')
                        return true;
                    else if (c == 'N' || c == 'n')
                        return true;
                    else if (c == 'O' || c == 'o')
                        return true;
                    else if (c == 'P' || c == 'p')
                        return true;
                    else if (c == 'Q' || c == 'q')
                        return true;
                    else if (c == 'R' || c == 'r')
                        return true;
                    else if (c == 'S' || c == 's')
                        return true;
                    else if (c == 'T' || c == 't')
                        return true;
                    else if (c == 'U' || c == 'u')
                        return true;
                    else if (c == 'V' || c == 'v')
                        return true;
                    else if (c == 'W' || c == 'w')
                        return true;
                    else if (c == 'X' || c == 'x')
                        return true;
                    else if (c == 'Y' || c == 'y')
                        return true;
                    else if (c == 'Z' || c == 'z')
                        return true;
                    else return false;
                }
                public static bool IsPunctuation(char c)
                {
                    if (c == '!')
                        return true;
                    else if (c == '.')
                        return true;
                    else if (c == ',')
                        return true;
                    else if (c == '?')
                        return true;
                    else if (c == '\"')
                        return true;
                    else if (c == '\'')
                        return true;
                    else if (c == ':')
                        return true;
                    else if (c == ';')
                        return true;
                    else return false;
                }
                public static bool IsSymbol(char c)
                {
                    if (c == '@')
                        return true;
                    else if (c == '#')
                        return true;
                    else if (c == '$')
                        return true;
                    else if (c == '%')
                        return true;
                    else if (c == '^')
                        return true;
                    else if (c == '&')
                        return true;
                    else if (c == '*')
                        return true;
                    else if (c == '(')
                        return true;
                    else if (c == ')')
                        return true;
                    else if (c == '-')
                        return true;
                    else if (c == '_')
                        return true;
                    else if (c == '+')
                        return true;
                    else if (c == '=')
                        return true;
                    else if (c == '[')
                        return true;
                    else if (c == ']')
                        return true;
                    else if (c == '{')
                        return true;
                    else if (c == '}')
                        return true;
                    else if (c == '|')
                        return true;
                    else if (c == '\\')
                        return true;
                    else if (c == '<')
                        return true;
                    else if (c == '>')
                        return true;
                    else if (c == '?')
                        return true;
                    else if (c == '/')
                        return true;
                    else return false;
                }
                public static bool IsNumeral(char c)
                {
                    if (c == '0')
                        return true;
                    else if (c == '1')
                        return true;
                    else if (c == '2')
                        return true;
                    else if (c == '3')
                        return true;
                    else if (c == '4')
                        return true;
                    else if (c == '5')
                        return true;
                    else if (c == '6')
                        return true;
                    else if (c == '7')
                        return true;
                    else if (c == '8')
                        return true;
                    else if (c == '9')
                        return true;
                    else return false;
                }
                public static bool IsWhitespace(char c)
                {
                    if (c == ' ')
                        return true;
                    return false;
                }
            }
        }
    }
}
