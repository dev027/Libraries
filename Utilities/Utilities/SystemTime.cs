using System;

namespace Utilities.Utilities
{
    /// <summary>
    /// Static class to be used in place of DateTime to get the current date and time.
    /// This allows the time to be fixed for testing purposed. It also exposes the dates
    ///  Yesterday and Tomorrow, which DateTime does not have.
    /// </summary>
    public static class SystemTime
    {
        #region Private Members

        /// <summary>
        /// Fixed time (DateTime.MinValue means no fixed time)
        /// </summary>
        private static DateTime _dateTime;

        #endregion Private Members

        #region Public Methods

        /// <summary>
        /// Fix the system time so that all the time functions return this value
        /// </summary>
        /// <param name="customDateTime">Fixed system time</param>
        public static void Set(DateTime customDateTime)
        {
            _dateTime = customDateTime;
        }

        /// <summary>
        /// Reset the system time so that all the time functions return the current time
        /// </summary>
        public static void Reset()
        {
            _dateTime = DateTime.MinValue;
        }

        #endregion Public Methods

        #region Public Properties

        /// <summary>
        /// return UTC time
        /// </summary>
        public static DateTime UtcNow => HaveCustomTime ? _dateTime : DateTime.UtcNow;

        /// <summary>
        /// Return local time
        /// </summary>
        public static DateTime Now => HaveCustomTime ? _dateTime : DateTime.Now;

        /// <summary>
        /// Return today's date
        /// </summary>
        public static DateTime Today => Now.Date;

        /// <summary>
        /// Return yesterday's date
        /// </summary>
        public static DateTime Yesterday => Today.AddDays(-1);

        /// <summary>
        /// Return tomorrow's date
        /// </summary>
        public static DateTime Tomorrow => Today.AddDays(1);

        /// <summary>
        /// Return datetime for 1st Jan 2000
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public static DateTime Jan1st2000 = new DateTime(2000, 1, 1);
        /// <summary>
        /// 
        /// Return datetime for 5th Dec 2015 10.15am
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public static DateTime Dec5th2015Time1015 = new DateTime(2015, 12, 05, 10, 15, 00);

        #endregion Public Properties

        #region Private methods

        /// <summary>
        /// True if custom time set
        /// </summary>
        private static bool HaveCustomTime => _dateTime != DateTime.MinValue;

        #endregion Private methods
    }
}