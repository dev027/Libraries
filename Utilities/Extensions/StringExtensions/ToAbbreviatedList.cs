using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilities.Extensions.StringBuilderExtensions;

namespace Utilities.Extensions.StringExtensions
{
    public static partial class StringExtensions
    {
        public static string ToAbbreviatedList(this IList<string> list,
            int maxIndividualCount = 2,
            string other = "other",
            string others = null,
            string and = "and")
        {
            if (maxIndividualCount < 1)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(maxIndividualCount),
                    maxIndividualCount,
                    "Must be at least 1");
            }
            if (list == null)
            {
                throw new ArgumentNullException(nameof(list));
            }

            // If only one element then return it
            int count = list.Count;

            if (count == 1) return list.First();

            // Build up the list of elements
            var sb = new StringBuilder(list.First());

            for (int i = 1; i < maxIndividualCount; i++)
            {
                // When appending element then separate with comma
                // except for the last one which is separated with an "and"
                sb.AppendJoin(list[i], i == count - 1 ? $" {and} " : ", ");
            }

            // If the list wasn't fully concatenated then append the reminder count
            if (maxIndividualCount < count)
            {
                int remainder = count - maxIndividualCount;

                // Cope if the remainder is singular or plural
                sb = sb.Append($" {and} {remainder} ");
                if (remainder == 1)
                {
                    sb.Append(other);
                }
                else
                {
                    sb.Append(others ?? $"{other}s");
                }
            }

            return sb.ToString();
        }
    }
}