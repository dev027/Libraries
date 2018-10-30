using System;
using Utilities.Extensions.ExceptionExtensions;

namespace Utilities.Exceptions
{
    public class DataValidationException : Exception
    {
        public string FieldName { get; private set; }

        public string Details { get; private set; }

        public DataValidationFailure DataValidationFailure { get; private set; }

        public DataValidationException(string fieldName, DataValidationFailure dataValidationFailure, int valueBoundary, int actualValue)
        {
            switch (dataValidationFailure)
            {
                case DataValidationFailure.StringTooShort:
                    InitComponent(fieldName, dataValidationFailure,
                        $"Length of {actualValue} is less than expected {valueBoundary}");
                    break;
                case DataValidationFailure.StringTooLong:
                    InitComponent(fieldName, dataValidationFailure,
                        $"Length of {actualValue} is more than allowed {valueBoundary}");
                    break;
                case DataValidationFailure.IntegerTooLow:
                    InitComponent(fieldName, dataValidationFailure,
                        $"Value of {actualValue} is less than expected {valueBoundary}");
                    break;
                case DataValidationFailure.IntegerTooHigh:
                    InitComponent(fieldName, dataValidationFailure,
                        $"Length of {actualValue} is more than allowed {valueBoundary}");
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(dataValidationFailure), dataValidationFailure, null);
            }
        }
        public DataValidationException(string fieldName, DataValidationFailure dataValidationFailure, decimal valueBoundary, decimal actualValue)
        {
            switch (dataValidationFailure)
            {
                case DataValidationFailure.DecimalTooLow:
                    InitComponent(fieldName, dataValidationFailure,
                        $"Value of {actualValue} is less than expected {valueBoundary}");
                    break;
                case DataValidationFailure.DecimalTooHigh:
                    InitComponent(fieldName, dataValidationFailure,
                        $"Length of {actualValue} is more than allowed {valueBoundary}");
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(dataValidationFailure), dataValidationFailure, null);
            }
        }
        public DataValidationException(string fieldName, DataValidationFailure dataValidationFailure, TimeSpan valueBoundary, TimeSpan actualValue)
        {
            switch (dataValidationFailure)
            {
                case DataValidationFailure.TimeSpanTooLow:
                    InitComponent(fieldName, dataValidationFailure,
                        $"Value of {actualValue} is less than expected {valueBoundary}");
                    break;
                case DataValidationFailure.TimeSpanTooHigh:
                    InitComponent(fieldName, dataValidationFailure,
                        $"Length of {actualValue} is more than allowed {valueBoundary}");
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(dataValidationFailure), dataValidationFailure, null);
            }
        }

        public DataValidationException(string fieldName, DataValidationFailure dataValidationFailure, DateTime? valueBoundary, DateTime? actualValue)
        {
            string type = fieldName.Contains("Time") ? "DateTime" : "Date";

            switch (dataValidationFailure)
            {
                case DataValidationFailure.DateTimeTooEarly:
                    InitComponent(fieldName, dataValidationFailure,
                        $"{type} of {actualValue} is earlier than expected {valueBoundary}");
                    break;
                case DataValidationFailure.DateTimeTooLate:
                    InitComponent(fieldName, dataValidationFailure,
                        $"{type} of {actualValue} is later than allowed {valueBoundary}");
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(dataValidationFailure), dataValidationFailure, null);
            }
        }
        public DataValidationException(string fieldName, DataValidationFailure dataValidationFailure)
        {
            switch (dataValidationFailure)
            {
                case DataValidationFailure.ParentEntityNull:
                    InitComponent(fieldName, dataValidationFailure, "Parent entity is null");
                    break;
                case DataValidationFailure.ForeignKeyNotPopulated:
                    InitComponent(fieldName, dataValidationFailure, "Foreign key not populated");
                    break;
                case DataValidationFailure.ForeignKeyPopulated:
                    InitComponent(fieldName, dataValidationFailure, "Foreign key populated");
                    break;
                case DataValidationFailure.ForeignKeyNegativeValue:
                    InitComponent(fieldName, dataValidationFailure, "Foreign key populated with a negative value");
                    break;
                case DataValidationFailure.ChildCollectionNotEmpty:
                    InitComponent(fieldName, dataValidationFailure, "Child collection is not empty");
                    break;
                case DataValidationFailure.DecimalIsZero:
                case DataValidationFailure.IntegerIsZero:
                    InitComponent(fieldName, dataValidationFailure, "Value unexpectedly zero");
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(dataValidationFailure), dataValidationFailure, null);
            }
        }

        public DataValidationException(string fieldName, DataValidationFailure dataValidationFailure, string actualValue)
        {
            switch (dataValidationFailure)
            {
                case DataValidationFailure.IllegalEnumValue:
                    InitComponent(fieldName, dataValidationFailure, $"Illegal enum value of {actualValue}");
                    break;
                case DataValidationFailure.IllegalValue:
                    InitComponent(fieldName, dataValidationFailure, $"Illegal value of {actualValue}");
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(dataValidationFailure), dataValidationFailure, null);
            }

        }
        public DataValidationException(string field1Name, string field2Name, DataValidationFailure dataValidationFailure)
        {
            switch (dataValidationFailure)
            {
                case DataValidationFailure.NoneOrBoth:
                    InitComponent(field1Name + "/" + field2Name, dataValidationFailure,
                        "Fields must be either both null or both have values");
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(dataValidationFailure), dataValidationFailure, null);
            }

        }
        public DataValidationException(
            string field1Name,
            string field2Name,
            DateTime value1,
            DateTime value2,
            DataValidationFailure dataValidationFailure)
        {
            switch (dataValidationFailure)
            {
                case DataValidationFailure.FromDateAfterToDate:
                    InitComponent(field1Name + "/" + field2Name, dataValidationFailure,
                        $"{field1Name} ({value1}) is after {field2Name} ({value2})");
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(dataValidationFailure), dataValidationFailure, null);
            }

        }

        public DataValidationException(string fieldName, DataValidationFailure dataValidationFailure, bool actualValue)
        {
            switch (dataValidationFailure)
            {
                case DataValidationFailure.IllegalValue:
                    InitComponent(fieldName, dataValidationFailure, $"Illegal boolean value of {actualValue}");
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(dataValidationFailure), dataValidationFailure, null);
            }

        }

        private void InitComponent(string fieldName, DataValidationFailure dataValidationFailure, string details = "")
        {
            FieldName = fieldName;
            DataValidationFailure = dataValidationFailure;
            Details = details;
        }


        public override string ToString()
        {
            return this.ExceptionToString(description => description
                .AppendFormat($", fieldName={FieldName}, reason={DataValidationFailure}, details={Details}"));
        }
    }

    public enum DataValidationFailure
    {
        ChildCollectionNotEmpty,
        DateTimeTooEarly,
        DateTimeTooLate,
        DecimalIsZero,
        DecimalTooHigh,
        DecimalTooLow,
        ForeignKeyNotPopulated,
        ForeignKeyPopulated,
        ForeignKeyNegativeValue,
        FromDateAfterToDate,
        IllegalEnumValue,
        IllegalValue,
        IntegerIsZero,
        IntegerTooHigh,
        IntegerTooLow,
        KeyNotPopulated,
        KeyPopulated,
        NoneOrBoth,
        ParentEntityNull,
        StringTooLong,
        StringTooShort,
        TimeSpanTooHigh,
        TimeSpanTooLow
    }
}