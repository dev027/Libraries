using System;

namespace Utilities.Constants
{
    /// <summary>
    /// Data Types for overriding the default mapping of column data type to property data types
    /// </summary>
    public enum ColumnDataType
    {
        BigInt,
        Int,
        Text,
        Numeric,
        Image
    }

    /// <summary>
    /// Convert the column data type into the correct value for either a SQl or Oracle database
    /// </summary>
    public static class ColumnDataTypeExtensions
    {
        public static string ToProviderSpecific(this ColumnDataType columnDataType, Provider dbProviderType)
        {
            switch (dbProviderType)
            {
                case Provider.SqlServer:
                    switch (columnDataType)
                    {
                        case ColumnDataType.BigInt:
                            return "bigint";
                        case ColumnDataType.Int:
                            return "int";
                        case ColumnDataType.Text:
                            return "text";
                        case ColumnDataType.Numeric:
                            return "numeric";
                        case ColumnDataType.Image:
                            return "image";
                        default:
                            throw new ArgumentOutOfRangeException(nameof(columnDataType), columnDataType, null);
                    }
                case Provider.Oracle:
                    switch (columnDataType)
                    {
                        case ColumnDataType.BigInt:
                            return "bigint";
                        case ColumnDataType.Int:
                            return "int";
                        case ColumnDataType.Text:
                            return "cblob";
                        case ColumnDataType.Numeric:
                            return "numeric";
                        case ColumnDataType.Image:
                            return "blob";
                        default:
                            throw new ArgumentOutOfRangeException(nameof(columnDataType), columnDataType, null);
                    }
                default:
                    throw new ArgumentOutOfRangeException(nameof(dbProviderType), dbProviderType, null);
            }
        }
    }
}