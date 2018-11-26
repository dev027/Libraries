using System.IO;
using System.Text.RegularExpressions;

namespace Utilities.Extensions.StringExtensions
{
    public static partial class StringExtensions
    {
        public static string StripInvalidFileNameChars(this string str)
        {
            return Regex.Replace(
                str,
                $"[{Regex.Escape(new string(Path.GetInvalidFileNameChars()))}]+",
                string.Empty);
        }
    }
}