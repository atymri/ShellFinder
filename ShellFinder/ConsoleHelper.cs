using System;

namespace ShellFinder
{
    /// <summary>
    /// Helper class for console output and formatting.
    /// </summary>
    public static class ConsoleHelper
    {
        /// <summary>
        /// Clears the console.
        /// </summary>
        public static void ClearConsole()
        {
            Console.Clear();
        }

        /// <summary>
        /// Prints a colorful ASCII banner.
        /// </summary>
        public static void PrintBanner()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Whell Finder - 1.0.0.0");
        }

        /// <summary>
        /// Prints text in specified color.
        /// </summary>
        public static void PrintColored(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        /// <summary>
        /// Returns colored text to be printed with Write or WriteLine.
        /// Note: This method changes the console color temporarily and returns an empty string,
        /// so use it only in Console.Write calls to get color effect.
        /// </summary>
        public static string ColorText(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ResetColor();
            return "";
        }

        /// <summary>
        /// Returns colored text without printing, for Console.Write usage.
        /// </summary>
        public static string Colorize(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ResetColor();
            return "";
        }
    }
}
