using System;

namespace Utilities.Extensions.StringExtensions
{
    public static partial class StringExtensions
    {
        /// <summary>
        /// Truncate string to specified length
        /// </summary>
        /// <param name="sourceString">Source String</param>
        /// <param name="length">Required length</param>
        /// <returns>Truncated string</returns>
        public static string Truncate(this string sourceString, int length)
        {
            if (length < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(length), "Must be greater or equal to zero");
            }

            if (sourceString == null || length == 0 || sourceString.Length == 0)
            {
                return string.Empty;
            }

            return sourceString.Substring(startIndex: 0, length: Math.Min(sourceString.Length, length));
        }
    }
}