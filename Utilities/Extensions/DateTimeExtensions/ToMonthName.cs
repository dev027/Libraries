using System;
using System.Globalization;

namespace Utilities.Extensions.DateTimeExtensions
{
    public static partial class DateTimeExtensions
    {
        /// <summary>
        /// Convert date to long month name
        /// </summary>
        /// <param name="dateTime">Date to convert</param>
        /// <returns>Long month name</returns>
        public static string ToMonthName(this DateTime dateTime)
        {
            return CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(dateTime.Month);
        }
    }
}