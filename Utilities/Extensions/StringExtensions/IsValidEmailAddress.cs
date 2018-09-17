using System;
using System.Net.Mail;

namespace Utilities.Extensions.StringExtensions
{
    public static partial class StringExtensions
    {
        /// <summary>
        /// Check is string is a valid email address
        /// </summary>
        /// <param name="email">String to check</param>
        /// <returns>True or False</returns>
        public static bool IsValidEmailAddress(this string email)
        {
            try
            {
                return new MailAddress(email).Address == email;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}