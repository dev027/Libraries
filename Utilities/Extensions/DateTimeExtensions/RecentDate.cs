using System;

namespace Utilities.Extensions.DateTimeExtensions
{
    public static partial class DateTimeExtensions
    {
        /// <summary>
        /// Convert a date into a more user friendly format.
        /// Friendlier formats are:
        ///     "Today"
        ///     "Yesterday"
        ///      Close Format (usually  day of the week) if within 7 days in the past
        ///      Distant format otherwise
        /// </summary>
        /// <param name="localDateTime">Local datetime value to convert</param>
        /// <param name="distantFormat">Distant date format</param>
        /// <param name="closeFormat">Close date format</param>
        /// <param name="showTimeIfToday">True if replace "Today" with the time</param>
        /// <param name="timeFormat">Time format</param>
        /// <returns>Formatted string date</returns>
        public static string RecentDate(this DateTime localDateTime,
            string distantFormat = null,
            string closeFormat = null,
            bool showTimeIfToday = false,
            string timeFormat = null)
        {
            if (localDateTime == DateTime.MaxValue) return Defaults.Forever;
            if (localDateTime == DateTime.MinValue) return Defaults.Always;

            int daysAgo = (int)(DateTime.Today - localDateTime.Date).TotalDays;

            switch (daysAgo)
            {
                case 0:
                    return showTimeIfToday
                        ? localDateTime.ToString(timeFormat ?? Defaults.TimeFormat).ToLowerInvariant()
                        : Defaults.Today;
                case 1:
                    return Defaults.Yesterday;
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                    return localDateTime.ToString(closeFormat ?? Defaults.CloseDateFormat);
                default:
                    return localDateTime.ToString(distantFormat ?? Defaults.DistantDateFormat);
            }
        }


    }
}