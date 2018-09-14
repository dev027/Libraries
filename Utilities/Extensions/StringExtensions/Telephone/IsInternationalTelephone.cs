namespace Utilities.Extensions.StringExtensions.Telephone
{
    public static partial class StringExtensions
    {
        /// <summary>
        ///     Check if telephone number is an international number or a local number
        /// </summary>
        /// <param name="telephone">Telephone number to check</param>
        /// <returns>True if international number</returns>
        /// <example>
        ///     --------------------------------
        ///     |VALUE                 |RESULT |
        ///     --------------------------------
        ///     |         +441455299100| TRUE  |
        ///     |          01455299100 | FALSE |
        ///     |Not a telephone number| FALSE |
        ///     --------------------------------
        /// </example>
        public static bool IsInternationalTelephone(this string telephone)
        {
            // Consider it an international telephone number if it starts with a '+'
            return telephone.StartsWith("+");
        }
    }
}