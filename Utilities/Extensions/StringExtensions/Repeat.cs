using System.Text;

namespace Utilities.Extensions.StringExtensions
{
    public static partial class StringExtensions
    {
        /// <summary>
        /// Return string of repeated characters
        /// </summary>
        /// <param name="charToRepeat">Character to repeat</param>
        /// <param name="repeat">Number of times to repeat</param>
        /// <returns>String with repeated characters</returns>
        public static string Repeat(this char charToRepeat, int repeat)
        {
            return new string(charToRepeat, repeat);
        }

        /// <summary>
        /// Return string of repeated strings
        /// </summary>
        /// <param name="stringToRepeat">String to repeat</param>
        /// <param name="repeat">Number of times to repeat</param>
        /// <returns>String with repeated string</returns>
        public static string Repeat(this string stringToRepeat, int repeat)
        {
            StringBuilder builder = new StringBuilder(repeat * stringToRepeat.Length);
            for (int i = 0; i < repeat; i++)
            {
                builder.Append(stringToRepeat);
            }

            return builder.ToString();
        }
    }
}