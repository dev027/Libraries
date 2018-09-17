using System;

namespace Utilities.Extensions.IntegerExtensions
{
    public static partial class IntegerExtensions
    {
        public static string ToOrdinalExcel(this int columnNumber)
        {
            var dividend = columnNumber;
            var columnName = string.Empty;

            while (dividend > 0)
            {
                var modulo = (dividend - 1) % 26;
                columnName = Convert.ToChar(65 + modulo) + columnName;
                dividend = (dividend - modulo) / 26;
            }

            return columnName;
        }
    }
}