using System;
using System.Collections.Generic;

namespace Utilities.Extensions.StringExtensions
{
    public static partial class StringExtensions
    {

        /// <summary>
        /// Split string by string
        /// </summary>
        /// <param name="toSplit">String to be split</param>
        /// <param name="splitOn">Token to split by</param>
        /// <returns>Split string</returns>
        public static IEnumerable<string> Split(this string toSplit, string splitOn)
        {
            return toSplit.Split(new[] { splitOn }, StringSplitOptions.None);
        }
    }
}