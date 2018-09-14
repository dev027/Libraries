using System;
using System.Globalization;

namespace Utilities.Extensions.DateTimeExtensions
{
    public static partial class DateTimeExtensions
    {
        /// <summary>
        /// Convert date to short month name
        /// </summary>
        /// <param name="dateTime">Date to convert</param>
        /// <returns>Short month name</returns>
        public static string ToShortMonthName(this DateTime dateTime)
        {
            return CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(dateTime.Month);
        }
    }
}