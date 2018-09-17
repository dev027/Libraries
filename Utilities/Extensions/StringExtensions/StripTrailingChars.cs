using System.Linq;

namespace Utilities.Extensions.StringExtensions
{
    public static partial class StringExtensions
    {
        /// <summary>
        /// Remove specified trailing characters
        /// </summary>
        /// <param name="stringToClean">String to clean</param>
        /// <param name="charsToStrip">Character to strip from the end</param>
        /// <returns>Cleaned string</returns>
        public static string StripTrailingChars(this string stringToClean, char[] charsToStrip)
        {
            if (stringToClean == null || charsToStrip.Length == 0) return stringToClean;

            int len = stringToClean.Length;
            while (len > 0 && charsToStrip.Contains(stringToClean[len - 1]))
            {
                len--;
            }
            return stringToClean.Substring(0, len);
        }
    }
}