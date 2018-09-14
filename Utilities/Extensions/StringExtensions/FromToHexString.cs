using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Utilities.Extensions.StringExtensions
{
    public static partial class StringExtensions
    {
        /// <summary>
        /// Convert plain text string into a hex string
        /// </summary>
        /// <param name="str">Plain text string to convert</param>
        /// <returns>Hex string</returns>
        public static string ToHexString(this string str)
        {
            if (str == null)
            {
                return null;
            }
            StringBuilder sb = new StringBuilder();

            var bytes = Encoding.Unicode.GetBytes(str);
            foreach (byte t in bytes)
            {
                sb.Append(t.ToString("X2"));
            }

            return sb.ToString(); // returns: "480065006C006C006F00200057006F0072006C006400" for "Hello world"
        }

        /// <summary>
        /// Convert  hex string into plain text
        /// </summary>
        /// <param name="hexString">Hex string to convert</param>
        /// <returns>Plain text</returns>
        public static string FromHexString(this string hexString)
        {
            if (hexString == null)
            {
                return null;
            }
            string hexStringWithoutHexCharacters = Regex.Replace(hexString, "[a-f|A-F|0-9]", "");

            if (hexStringWithoutHexCharacters.Length > 0)
            {
                throw new ArgumentException("Non-hex characters found", nameof(hexString));
            }
            if (hexString.Length % 4 != 0)
            {
                throw new ArgumentException("Must be four hex numbers per character", nameof(hexString));
            }
            byte[] bytes = new byte[hexString.Length / 2];
            for (int i = 0; i < bytes.Length; i++)
            {
                bytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            }

            return Encoding.Unicode.GetString(bytes); // returns: "Hello world" for "480065006C006C006F00200057006F0072006C006400"
        }
    }
}