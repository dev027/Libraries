using System;

namespace Utilities.Extensions.StringExtensions
{
    public static partial class StringExtensions
    {
        /// <summary>
        /// Replace last occurrence of string with another string
        /// </summary>
        /// <param name="haystack">String to search for match</param>
        /// <param name="oldNeedle">Match to search for</param>
        /// <param name="newNeedle">Replacement text</param>
        /// <returns>String with replacement text</returns>
        public static string ReplaceLastOccurrence(this string haystack, string oldNeedle, string newNeedle)
        {
            if (string.IsNullOrEmpty(haystack))
            {
                return haystack;
            }

            if (string.IsNullOrEmpty(oldNeedle))
            {
                return haystack;
            }

            if (string.IsNullOrEmpty(newNeedle))
            {
                newNeedle = string.Empty;
            }

            int pos = haystack.LastIndexOf(oldNeedle, StringComparison.Ordinal);
            if (pos == -1)
            {
                return haystack;
            }

            return haystack.Substring(0, pos) + newNeedle + haystack.Substring(pos + oldNeedle.Length);
        }
    }
}