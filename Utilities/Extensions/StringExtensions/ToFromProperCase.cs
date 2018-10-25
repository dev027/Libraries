using System.Globalization;
using System.Text;

namespace Utilities.Extensions.StringExtensions
{
    public static partial class StringExtensions
    {
        /// <summary>
        /// Convert string to proper case
        /// </summary>
        /// <param name="text">Text to convert</param>
        /// <param name="isPreserveSpaces">True if spaces are to conserved</param>
        /// <returns>Converted string</returns>
        /// <example>
        /// Using: "this is my test string"
        ///
        ///  Without space preservation: "ThisIsMyTestString"
        ///  With space preservation: "This Is My Test String"
        ///
        /// </example>
        public static string ToProperCase(this string text, bool isPreserveSpaces = false)
        {
            StringBuilder properText = new StringBuilder();

            for (int i = 0; i < text.Length; i++)
            {
                if (i == 0)
                {
                    properText.Append(text[i].ToString(CultureInfo.InvariantCulture).ToUpper());
                }
                else if (text[i - 1] == ' ')
                {
                    properText.Append(text[i].ToString(CultureInfo.InvariantCulture).ToUpper());
                }
                else
                {
                    if (text[i] != ' ' || isPreserveSpaces)
                    {
                        properText.Append(text[i].ToString(CultureInfo.InvariantCulture).ToLower());
                    }
                }
            }

            return properText.ToString();
        }

        /// <summary>
        /// Converts Proper Case into words
        /// </summary>
        /// <param name="text">Text to split</param>
        /// <param name="preserveAcronyms"></param>
        /// <param name="gap">Text to put between the words</param>
        /// <returns></returns>
        /// <example>
        /// Converts "ThisIsAWord" into "This Is A Word"
        /// and "ThisIsAnHTMLDocument" into "This Is An HTML Document"
        /// </example>
        public static string FromProperCase(this string text, bool preserveAcronyms = true, string gap = " ")
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return string.Empty;
            }

            StringBuilder newText = new StringBuilder(text.Length * 2);
            newText.Append(text[0]);
            for (int i = 1; i < text.Length; i++)
            {
                if (char.IsUpper(text[i]))
                {
                    bool insertGap = false;
                    if (preserveAcronyms)
                    {
                        if (text[i - 1] != ' ' && !char.IsUpper(text[i - 1]))
                        {
                            insertGap = true;
                        }
                        if (char.IsUpper(text[i - 1]) &&
                            i < text.Length - 1 &&
                            !char.IsUpper(text[i + 1])
                        )
                        {
                            insertGap = true;
                        }
                    }
                    else
                    {
                        insertGap = true;
                    }
                    if (insertGap)
                    {
                        newText.Append(gap);
                    }
                }
                newText.Append(text[i]);
            }
            return newText.ToString();
        }
    }
}