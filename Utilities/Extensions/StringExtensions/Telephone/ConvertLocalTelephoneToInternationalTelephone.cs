namespace Utilities.Extensions.StringExtensions.Telephone
{
    public static partial class StringExtensions
    {
        /// <summary>
        ///     Convert local telephone number to international telephone number
        /// </summary>
        /// <param name="localTelephone">Local telephone number</param>
        /// <param name="defaultCountryCallingCode">Default country calling code (e.g, UK = "+44")</param>
        /// <returns>International telephone number</returns>
        /// <remarks>
        ///     Drops any leading zero and prefixes with the default country code that was set up in the constructor
        /// </remarks>
        public static string ConvertLocalTelephoneToInternationalTelephone(
            this string localTelephone,
            string defaultCountryCallingCode)
        {
            return localTelephone[0] == '0'
                ? defaultCountryCallingCode + localTelephone.Substring(1)
                : defaultCountryCallingCode + localTelephone;
        }
    }
}