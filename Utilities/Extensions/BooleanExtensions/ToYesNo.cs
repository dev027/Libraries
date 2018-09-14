namespace Utilities.Extensions.BooleanExtensions
{
    public static partial class BooleanExtensions
    {
        /// <summary>
        /// Convert to "Yes" or "No"
        /// </summary>
        /// <param name="value">Value to convert</param>
        /// <param name="yesValue">Alternate value for Yes</param>
        /// <param name="noValue">Alternate value for No</param>
        /// <returns>"Yes" or "No"</returns>
        public static string ToYesNo(this bool value,
            string yesValue = null,
            string noValue = null)
        {
            return value
                ? yesValue ?? Defaults.Yes
                : noValue ?? Defaults.No;
        }
    }
}