namespace Utilities.Extensions.DateTimeExtensions
{
    public static partial class DateTimeExtensions
    {
        /// <summary>
        /// Defaults string and datetime formats for other library routines
        /// </summary>
        /// <see cref="RecentDate"></see>
        /// <see cref="NearFutureDate"></see>
        private static class Defaults
        {
            public static string Forever = "Forever";
            public static string Always = "Always";
            public static string Today = "Today";
            public static string Tomorrow = "Tomorrow";
            public static string Yesterday = "Yesterday";

            public static string DistantDateFormat = "dd-MMM-yyyy";
            public static string CloseDateFormat = "dddd";
            public static string TimeFormat = "h:mmtt";
        }

        /// <summary>
        /// Override the default strings and date formats for other library routines
        /// </summary>
        /// <param name="forever">Text for dateTime.MaxValue</param>
        /// <param name="always">Text for dateTime.MinValue</param>
        /// <param name="today">Text replacement for "Today"</param>
        /// <param name="tomorrow">Text replacement for "Tomorrow"</param>
        /// <param name="yesterday">Text replacement for "Yesterday"</param>
        /// <param name="distantDateFormat">Date format for dates more that 7 days away</param>
        /// <param name="closeDateFormat">Date format for dates within 7 days</param>
        /// <param name="timeFormat">Time format</param>
        public static void SetDefaults(
            string forever = null,
            string always = null,
            string today = null,
            string tomorrow = null,
            string yesterday = null,
            string distantDateFormat = null,
            string closeDateFormat = null,
            string timeFormat = null)
        {
            if (forever != null)
            {
                Defaults.Forever = forever;
            }

            if (always != null)
            {
                Defaults.Always = always;
            }

            if (today != null)
            {
                Defaults.Today = today;
            }

            if (tomorrow != null)
            {
                Defaults.Tomorrow = tomorrow;
            }

            if (yesterday != null)
            {
                Defaults.Yesterday = yesterday;
            }

            if (distantDateFormat != null)
            {
                Defaults.DistantDateFormat = distantDateFormat;
            }

            if (closeDateFormat != null)
            {
                Defaults.CloseDateFormat = closeDateFormat;
            }

            if (timeFormat != null)
            {
                Defaults.TimeFormat = timeFormat;
            }
        }
    }
}
