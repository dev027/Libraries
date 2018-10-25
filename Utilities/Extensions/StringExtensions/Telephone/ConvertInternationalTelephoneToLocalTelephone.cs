using Utilities.Constants;

namespace Utilities.Extensions.StringExtensions.Telephone
{
    public static partial class StringExtensions
    {
        /// <summary>
        ///     Convert an international telephone number to a local telephone number if we have the rules
        /// </summary>
        /// <param name="internationalTelephone">International telephone number</param>
        /// <returns>Local telephone number OR original telephone number if we don't have the rules</returns>
        /// <remarks>
        ///     If the telephone number passed is NOT an international telephone number then just return the original
        ///     If we don't have the rules for calculating the local telephone number for this country then return the original
        /// </remarks>
        public static string ConvertInternationalTelephoneToLocalTelephone(this string internationalTelephone)
        {
            if (!internationalTelephone.IsInternationalTelephone())
            {
                return internationalTelephone;
            }

            switch (internationalTelephone.Substring(1, 1))
            {
                case "4":
                    switch (internationalTelephone.Substring(2, 1))
                    {
                        case "4": // +44 - United Kingdom
                            return internationalTelephone.ConvertInternationalTelephoneToUkTelephone();
                    }

                    break;
            }

            // No rules - return the original
            return internationalTelephone;
        }

        /// <summary>
        ///     Convert international telephone number for United Kingdom to local telephone number
        /// </summary>
        /// <param name="internationalTelephone">International telephone number</param>
        /// <returns>Local telephone number</returns>
        private static string ConvertInternationalTelephoneToUkTelephone(this string internationalTelephone)
        {
            // Replace the international prefix for the United Kingdom with a '0'
            return internationalTelephone.ReplaceFirstOccurrence(TelephoneCountryCallingCode.UnitedKingdom, "0");
        }

    }
}