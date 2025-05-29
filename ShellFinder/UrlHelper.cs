using System;

namespace ShellFinder
{
    /// <summary>
    /// Helper class to fix and validate URLs.
    /// </summary>
    public static class UrlHelper
    {
        /// <summary>
        /// Fixes the base URL to ensure it contains a valid scheme and trailing slash.
        /// </summary>
        /// <param name="baseUrl">Input URL string</param>
        /// <returns>Fixed URL string</returns>
        public static string FixUrl(string baseUrl)
        {
            if (!Uri.TryCreate(baseUrl, UriKind.Absolute, out var uri))
            {
                baseUrl = "https://" + baseUrl;
                if (!Uri.TryCreate(baseUrl, UriKind.Absolute, out uri))
                {
                    baseUrl = "http://" + baseUrl;
                }
            }

            if (!baseUrl.EndsWith("/"))
                baseUrl += "/";

            return baseUrl;
        }
    }
}
