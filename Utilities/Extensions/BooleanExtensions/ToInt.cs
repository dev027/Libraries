namespace Utilities.Extensions.BooleanExtensions
{
    public static partial class BooleanExtensions
    {
        /// <summary>
        /// Convert true to 1 and false to 0
        /// </summary>
        /// <param name="boolean">Value to convert</param>
        /// <returns>1 or 0</returns>
        public static int ToInit(this bool boolean)
        {
            return boolean ? 1 : 0;
        }
    }
}