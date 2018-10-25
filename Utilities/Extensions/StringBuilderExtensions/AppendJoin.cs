using System.Linq;
using System.Text;

namespace Utilities.Extensions.StringBuilderExtensions
{
    public static partial class StringBuilderExtensions
    {
        /// <summary>
        /// Append the  array of strings to this string builder.
        /// Separate the current contents (if any) and the strings by the joiner
        /// </summary>
        /// <param name="sb">String builder</param>
        /// <param name="join">Joiner string</param>
        /// <param name="text">Array of strings to append</param>
        public static void AppendJoin(this StringBuilder sb, string join, params object[] text)
        {
            foreach (object t in text.Where(t => t != null))
            {
                if (sb.Length > 0)
                {
                    sb.Append(join);
                }
                sb.Append(t);
            }
        }

        /// <summary>
        /// Append the text to this string builder, prefixed by the joiner if string builder already has text
        /// </summary>
        /// <param name="sb">String builder</param>
        /// <param name="join">Joiner string</param>
        /// <param name="text">Strings to append</param>
        public static void AppendJoin(this StringBuilder sb, string join, string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return;
            }

            if (sb.Length > 0)
            {
                sb.Append(join);
            }
            sb.Append(text);
        }
    }
}