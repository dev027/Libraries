using System.Collections.Generic;

namespace Utilities.Extensions.ListExtensions
{
    public static partial class ListExtensions
    {
        public static void AddRange<T>(this IList<T> list, IEnumerable<T> newItems)
        {
            foreach (T newItem in newItems)
            {
                list.Add(newItem);
            }
        }
    }
}