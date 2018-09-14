using System.IO;
using System.Text.RegularExpressions;

namespace Utilities.Extensions.StringExtensions
{
    public static partial class StringExtensions
    {
        /// <summary>
        /// Remove any characters that are invalid in a file name
        /// </summary>
        /// <param name="source">String to parse</param>
        /// <param name="replacementString">String to replace invalid characters with (default = "")</param>
        /// <returns>String without invalid file name characters</returns>
        public static string RemoveInvalidFileNameChars(this string source, string replacementString = "")
        {
            string regexPattern = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());
            Regex regex = new Regex($"[{Regex.Escape(regexPattern)}]");
            string result = regex.Replace(source, replacementString);
            return result.Trim();
        }
    }
}