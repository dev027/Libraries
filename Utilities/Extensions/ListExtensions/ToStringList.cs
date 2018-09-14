using System.Collections.Generic;
using System.Text;
using Utilities.Extensions.StringBuilderExtensions;

namespace Utilities.Extensions.ListExtensions
{
    public static partial class ListExtensions
    {
        /// <summary>
        /// Convert list into a string separated by specific string
        /// </summary>
        /// <typeparam name="T">List type</typeparam>
        /// <param name="list">List to convert</param>
        /// <param name="separator">Separator (defaults to comma)</param>
        /// <returns>List as a string OR null if list is null</returns>
        public static string ToStringList<T>(this IList<T> list, string separator = ",")
        {
            if (list == null) return null;

            StringBuilder sb = new StringBuilder();
            foreach (var item in list)
            {
                sb.AppendJoin(separator, item.ToString());
            }

            return sb.ToString();
        }
    }
}