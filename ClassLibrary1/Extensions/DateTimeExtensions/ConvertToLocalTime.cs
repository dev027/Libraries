using System;

namespace Utilities.Extensions.DateTimeExtensions
{
    public static partial class DateTimeExtensions
    {
        public static DateTime ConvertToLocalTime(this DateTime utcDateTime, TimeZoneInfo timeZoneInfo)
        {
            return utcDateTime == DateTime.MinValue || utcDateTime == DateTime.MaxValue
                ? utcDateTime
                : TimeZoneInfo.ConvertTimeFromUtc(
                    DateTime.SpecifyKind(utcDateTime, DateTimeKind.Utc),
                    timeZoneInfo);
        }

        public static DateTime ConvertToLocalTime(this DateTime utcDateTime, string timeZoneIdentity = null)
        {
            var timeZoneInfo = timeZoneIdentity == null
                ? TimeZoneInfo.Local
                : TimeZoneInfo.FindSystemTimeZoneById(timeZoneIdentity);

            return utcDateTime == DateTime.MinValue || utcDateTime == DateTime.MaxValue
                ? utcDateTime
                : TimeZoneInfo.ConvertTimeFromUtc(
                    DateTime.SpecifyKind(utcDateTime, DateTimeKind.Utc),
                    timeZoneInfo);
        }
    }
}