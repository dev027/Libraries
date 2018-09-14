using System.Linq;
using System.Text;

namespace Utilities.Extensions.StringBuilderExtensions
{
    public static partial class StringBuilderExtensions
    {
        /// <summary>
        /// Append array of strings to StringBuilder
        /// </summary>
        /// <param name="sb">StringBuilder</param>
        /// <param name="text">Array of strings to append</param>
        public static void Append(this StringBuilder sb, params object[] text)
        {
            foreach (object t in text.Where(t => t != null))
            {
                sb.Append(t);
            }
        }
    }
}