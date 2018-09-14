namespace Utilities.Extensions.BooleanExtensions
{
    public static partial class BooleanExtensions
    {
        /// <summary>
        /// Convert to "True" or "False"
        /// </summary>
        /// <param name="value">Value to convert</param>
        /// <param name="trueValue">Alternate value for True</param>
        /// <param name="falseValue">Alternate value for False</param>
        /// <returns>"True" or "False"</returns>
        public static string ToTrueFalse(this bool value,
            string trueValue = null,
            string falseValue = null)
        {
            return value
                ? trueValue ?? Defaults.True
                : falseValue ?? Defaults.False;
        }
    }
}