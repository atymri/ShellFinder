using System;
using System.Threading.Tasks;

namespace ShellFinder
{
    /// <summary>
    /// Entry point of the ShellFinder application.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main async entry method.
        /// </summary>
        static async Task Main(string[] args)
        {
            ConsoleHelper.ClearConsole();

            ConsoleHelper.PrintBanner();

            Console.Write(ConsoleHelper.Colorize("Enter the domain: ", ConsoleColor.Cyan));
            string baseUrl = Console.ReadLine()?.Trim() ?? "";

            Console.Write(ConsoleHelper.Colorize("Enter the shell wordlist file: ", ConsoleColor.Cyan));
            string wordlistPath = Console.ReadLine()?.Trim() ?? "";

            if (!System.IO.File.Exists(wordlistPath))
            {
                ConsoleHelper.PrintColored($"[!] Wordlist not found: {wordlistPath}", ConsoleColor.Red);
                return;
            }

            ConsoleHelper.PrintColored(new string('-', 50), ConsoleColor.Cyan);
            ConsoleHelper.PrintColored($"Base Domain : {baseUrl}", ConsoleColor.Cyan);
            ConsoleHelper.PrintColored($"Wordlist Path : {wordlistPath}", ConsoleColor.Cyan);
            ConsoleHelper.PrintColored(new string('-', 50), ConsoleColor.Cyan);

            var shells = await System.IO.File.ReadAllLinesAsync(wordlistPath);

            ConsoleHelper.PrintColored("[+] Wordlist loaded successfully!", ConsoleColor.Green);
            ConsoleHelper.PrintColored($"[+] Total shells to check: {shells.Length}", ConsoleColor.Green);

            baseUrl = UrlHelper.FixUrl(baseUrl);

            await ShellScanner.ScanShellsAsync(baseUrl, shells);

            ConsoleHelper.PrintColored("[+] Scan complete.", ConsoleColor.Green);
        }
    }
}
