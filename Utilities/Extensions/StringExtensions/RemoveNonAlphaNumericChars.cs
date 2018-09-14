using System;

namespace Utilities.Extensions.StringExtensions
{
    public static partial class StringExtensions
    {
        /// <summary>
        /// Remove all non-alphanumeric characters from string
        /// </summary>
        /// <param name="oldString">String to remove characters from</param>
        /// <returns>String with characters removed</returns>
        public static string RemoveNonAlphaNumericChars(this string oldString)
        {
            return new string(Array.FindAll(oldString.ToCharArray(), char.IsLetterOrDigit));
        }
    }
}