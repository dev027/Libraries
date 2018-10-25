namespace Utilities.Extensions.StringExtensions
{
    public static partial class StringExtensions
    {
        /// <summary>
        /// Check if string isn't null or empty
        /// </summary>
        /// <param name="str">String to check</param>
        /// <returns>False if null or empty; True if at least 1 character</returns>
        public static bool HasValue(string str)
        {
            return !string.IsNullOrEmpty(str);
        }
    }
}