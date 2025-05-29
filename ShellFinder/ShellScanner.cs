using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ShellFinder
{
    /// <summary>
    /// Handles scanning shells on the target domain.
    /// </summary>
    public static class ShellScanner
    {
        private static readonly HttpClient httpClient = new()
        {
            Timeout = TimeSpan.FromSeconds(5)
        };

        /// <summary>
        /// Scans shells by appending shell paths to the base URL and checking availability.
        /// Limits concurrency to 10 parallel tasks.
        /// </summary>
        /// <param name="baseUrl">Base domain URL</param>
        /// <param name="shells">List of shell paths</param>
        public static async Task ScanShellsAsync(string baseUrl, IEnumerable<string> shells)
        {
            var semaphore = new SemaphoreSlim(10);
            var tasks = new List<Task>();

            foreach (var shell in shells)
            {
                await semaphore.WaitAsync();

                tasks.Add(Task.Run(async () =>
                {
                    try
                    {
                        string url = $"{baseUrl}{shell}";
                        string result = await CheckUrlAsync(url);
                        if (!string.IsNullOrEmpty(result))
                        {
                            Console.WriteLine(result);
                        }
                    }
                    finally
                    {
                        semaphore.Release();
                    }
                }));
            }

            await Task.WhenAll(tasks);
        }

        /// <summary>
        /// Checks if the given URL is accessible (status 200).
        /// </summary>
        /// <param name="url">URL to check</param>
        /// <returns>Colored status string</returns>
        private static async Task<string> CheckUrlAsync(string url)
        {
            try
            {
                using var response = await httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    return ConsoleHelper.ColorText("[FOUND] ", ConsoleColor.Green) + url;
                }
                else
                {
                    return ConsoleHelper.ColorText("[-] ", ConsoleColor.Red) + url;
                }
            }
            catch
            {
                return ConsoleHelper.ColorText("[!] Error while trying ", ConsoleColor.Red) + url;
            }
        }
    }
}
