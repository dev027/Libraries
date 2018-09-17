namespace Utilities.Extensions.IntegerExtensions
{
    public static partial class IntegerExtensions
    {
        /// <summary>
        /// Convert non-zero to true and zero to false
        /// </summary>
        /// <param name="intValue">Integer to convert</param>
        /// <returns>True or False</returns>
        public static bool ToBoolean(this int intValue)
        {
            return intValue != 0;
        }
    }
}