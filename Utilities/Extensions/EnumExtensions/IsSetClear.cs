using System;
namespace Utilities.Extensions.EnumExtensions
{
    public static class EnumExtensions
    {
        /// <summary>
        /// Returns true all specified bits are set
        /// </summary>
        /// <typeparam name="T">Enum type</typeparam>
        /// <param name="enumValue">Enum value to test</param>
        /// <param name="value">Bit pattern to test against</param>
        /// <returns>True if all specified bits are set</returns>
        public static bool IsSet<T>(this Enum enumValue, T value)
        {
            return ((int)(object)enumValue & (int)(object)value) == (int)(object)value;
        }

        /// <summary>
        /// Return true unless all specified bits are sets=
        /// </summary>
        /// <typeparam name="T">Enum type</typeparam>
        /// <param name="enumValue">Enum value to test</param>
        /// <param name="value">Bit pattern to test against</param>
        /// <returns>True unless all specified bits are set</returns>
        public static bool IsClear<T>(this Enum enumValue, T value)
        {
            return !enumValue.IsSet(value);
        }
    }
}