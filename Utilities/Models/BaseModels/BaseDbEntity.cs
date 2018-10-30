using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Utilities.Exceptions;
using Utilities.Extensions.AnnotationExtensions;
using Utilities.Extensions.ObjectExtensions;

namespace Utilities.Models.BaseModels
{
    public abstract class BaseDbEntity
    {
        public virtual void OnModelCreating(ModelBuilder modelBuilder) { }

        public virtual void Validate(bool isAdd = false)
        {
        }

        #region Validate

        protected void ValidateString(string fieldName)
        {
            int actualLength = this.GetValue<string>(fieldName)?.Length ?? 0;
            int minLength = this.GetAttributeFrom<StringLengthAttribute>(fieldName).MinimumLength;
            int maxLength = this.GetAttributeFrom<StringLengthAttribute>(fieldName).MaximumLength;

            ValidateString(fieldName, actualLength, minLength, maxLength);
        }

        protected void ValidateString(string fieldName, int minLength, int maxLength)
        {
            int actualLength = this.GetValue<string>(fieldName)?.Length ?? 0;
            ValidateString(fieldName, actualLength, minLength, maxLength);
        }
        protected static void ValidateString(string fieldName, int actualLength, int minLength, int maxLength)
        {
            if (actualLength < minLength)
            {
                throw new DataValidationException(fieldName, DataValidationFailure.StringTooShort, minLength, actualLength);
            }
            if (actualLength > maxLength)
            {
                throw new DataValidationException(fieldName, DataValidationFailure.StringTooLong, maxLength, actualLength);
            }
        }

        protected void ValidateForeignKeyPopulated(string fieldName, bool mustBeZero = false)
        {
            int fieldValue = this.GetValue<int>(fieldName);
            if (mustBeZero)
            {
                if (fieldValue != 0)
                {
                    throw new DataValidationException(fieldName, DataValidationFailure.ForeignKeyPopulated);
                }
            }
            else
            {
                if (fieldValue == 0)
                {
                    throw new DataValidationException(fieldName, DataValidationFailure.ForeignKeyNotPopulated);
                }
                if (fieldValue < 0)
                {
                    throw new DataValidationException(fieldName, DataValidationFailure.ForeignKeyNegativeValue);
                }
            }
        }

        protected void ValidateBigForeignKeyPopulated(string fieldName, bool mustBeZero = false)
        {
            long fieldValue = this.GetValue<long>(fieldName);
            if (mustBeZero)
            {
                if (fieldValue != 0)
                {
                    throw new DataValidationException(fieldName, DataValidationFailure.ForeignKeyPopulated);
                }
            }
            else
            {
                if (fieldValue == 0)
                {
                    throw new DataValidationException(fieldName, DataValidationFailure.ForeignKeyNotPopulated);
                }
                if (fieldValue < 0)
                {
                    throw new DataValidationException(fieldName, DataValidationFailure.ForeignKeyNegativeValue);
                }
            }
        }
        protected void ValidateOptionalForeignKeyPopulated(string fieldName, bool mustBeZeroIfPopulated = false)
        {
            int? fieldValue = this.GetValue<int?>(fieldName);

            if (fieldValue.HasValue)
            {
                if (mustBeZeroIfPopulated)
                {
                    if (fieldValue != 0)
                    {
                        throw new DataValidationException(fieldName, DataValidationFailure.ForeignKeyPopulated);
                    }
                }
                else
                {
                    if (fieldValue == 0)
                    {
                        throw new DataValidationException(fieldName, DataValidationFailure.ForeignKeyNotPopulated);
                    }

                    if (fieldValue < 0)
                    {
                        throw new DataValidationException(fieldName, DataValidationFailure.ForeignKeyNegativeValue);
                    }
                }
            }
        }
        protected void ValidateOptionalBigForeignKeyPopulated(string fieldName, bool mustBeZeroIfPopulated = false)
        {
            long? fieldValue = this.GetValue<long?>(fieldName);
            if (fieldValue.HasValue)
            {
                if (mustBeZeroIfPopulated)
                {
                    if (fieldValue != 0)
                    {
                        throw new DataValidationException(fieldName, DataValidationFailure.ForeignKeyPopulated);
                    }
                }
                else
                {
                    if (fieldValue == 0)
                    {
                        throw new DataValidationException(fieldName, DataValidationFailure.ForeignKeyNotPopulated);
                    }

                    if (fieldValue < 0)
                    {
                        throw new DataValidationException(fieldName, DataValidationFailure.ForeignKeyNegativeValue);
                    }
                }
            }
        }

        protected void ValidateId(string fieldName, bool isAdd)
        {
            int fieldValue = this.GetValue<int>(fieldName);
            if (isAdd)
            {
                if (fieldValue != 0)
                {
                    throw new DataValidationException(fieldName, DataValidationFailure.KeyPopulated);
                }
            }
            else
            {
                if (fieldValue == 0)
                {
                    throw new DataValidationException(fieldName, DataValidationFailure.KeyNotPopulated);
                }

            }
        }
        protected void ValidateBigId(string fieldName, bool isAdd)
        {
            long fieldValue = this.GetValue<long>(fieldName);
            if (isAdd)
            {
                if (fieldValue != 0)
                {
                    throw new DataValidationException(fieldName, DataValidationFailure.KeyPopulated);
                }
            }
            else
            {
                if (fieldValue == 0)
                {
                    throw new DataValidationException(fieldName, DataValidationFailure.KeyNotPopulated);
                }

            }
        }

        protected void ValidateIntegerRange(string fieldName)
        {
            int? fieldValue = this.GetValue<int?>(fieldName);

            int minValue = (int)this.GetAttributeFrom<RangeAttribute>(fieldName).Minimum;
            int maxValue = (int)this.GetAttributeFrom<RangeAttribute>(fieldName).Maximum;

            ValidateIntegerRange(fieldName, fieldValue, minValue, maxValue);
        }

        protected static void ValidateIntegerRange(string fieldName, int? fieldValue, int minValue, int maxValue)
        {
            if (fieldValue.HasValue && fieldValue < minValue)
            {
                throw new DataValidationException(fieldName, DataValidationFailure.IntegerTooLow, minValue, fieldValue.Value);
            }
            if (fieldValue.HasValue && fieldValue > maxValue)
            {
                throw new DataValidationException(fieldName, DataValidationFailure.IntegerTooHigh, maxValue, fieldValue.Value);
            }
        }

        protected void ValidateIntegerNonZero(string fieldName)
        {
            int fieldValue = this.GetValue<int>(fieldName);

            if (fieldValue == 0)
            {
                throw new DataValidationException(fieldName, DataValidationFailure.IntegerIsZero);
            }
        }

        protected static void ValidateDecimalRange(BaseDbEntity baseDbEntity, string fieldName, decimal? fieldValue)
        {
            decimal minValue = Convert.ToDecimal(baseDbEntity.GetAttributeFrom<RangeAttribute>(fieldName).Minimum);
            decimal maxValue = Convert.ToDecimal(baseDbEntity.GetAttributeFrom<RangeAttribute>(fieldName).Maximum);

            ValidateDecimalRange(fieldName, fieldValue, minValue, maxValue);
        }

        protected static void ValidateDecimalRange(string fieldName, decimal? fieldValue, decimal minValue, decimal maxValue)
        {
            if (fieldValue.HasValue && fieldValue < minValue)
            {
                throw new DataValidationException(fieldName, DataValidationFailure.DecimalTooLow, minValue, fieldValue.Value);
            }
            if (fieldValue.HasValue && fieldValue > maxValue)
            {
                throw new DataValidationException(fieldName, DataValidationFailure.DecimalTooHigh, maxValue, fieldValue.Value);
            }
        }
        protected void ValidateDecimalNonZero(string fieldName)
        {
            decimal fieldValue = this.GetValue<decimal>(fieldName);
            if (fieldValue == 0)
            {
                throw new DataValidationException(fieldName, DataValidationFailure.DecimalIsZero);
            }
        }


        protected static void ValidateDateRange(string fieldName, DateTime? fieldValue, DateTime minValue, DateTime maxValue)
        {
            if (fieldValue.HasValue && fieldValue < minValue)
            {
                throw new DataValidationException(fieldName, DataValidationFailure.DateTimeTooEarly, minValue, fieldValue.Value);
            }
            if (fieldValue.HasValue && fieldValue > maxValue)
            {
                throw new DataValidationException(fieldName, DataValidationFailure.DateTimeTooLate, maxValue, fieldValue.Value);
            }
        }

        protected static void ValidateFromToDate(
            string fromFieldName,
            DateTime? fromDate,
            string toFieldName,
            DateTime? toDate,
            int maxRangeDays = int.MaxValue)
        {
            if (fromDate.HasValue && toDate.HasValue)
            {
                if (fromDate > toDate)
                {
                    throw new DataValidationException(fromFieldName, toFieldName, fromDate.Value, toDate.Value,
                        DataValidationFailure.FromDateAfterToDate);
                }
                int dateRangeDays = (int)(toDate.Value - fromDate.Value).TotalDays;

                if (dateRangeDays >= maxRangeDays)
                {
                    throw new DataValidationException(string.Join("/", fromFieldName, toFieldName, "Range"),
                        DataValidationFailure.IntegerTooLow,
                        maxRangeDays,
                        dateRangeDays);
                }
            }
        }

        ////protected static void ValidateTimeSpanRange(BaseDbEntity baseDbEntity, string fieldName, TimeSpan? fieldValue)
        ////{
        ////    TimeSpan minValue = TimeSpan.Parse(baseDbEntity.GetAttributeFrom<TimeSpanValidatorAttribute>(fieldName).MinValueString);
        ////    TimeSpan maxValue = TimeSpan.Parse(baseDbEntity.GetAttributeFrom<TimeSpanValidatorAttribute>(fieldName).MaxValueString);

        ////    ValidateTimeSpanRange(fieldName, fieldValue, minValue, maxValue);
        ////}
        protected static void ValidateTimeSpanRange(string fieldName, TimeSpan? fieldValue, TimeSpan minValue, TimeSpan maxValue)
        {
            if (fieldValue.HasValue && fieldValue < minValue)
            {
                throw new DataValidationException(fieldName, DataValidationFailure.TimeSpanTooLow, minValue, fieldValue.Value);
            }
            if (fieldValue.HasValue && fieldValue > maxValue)
            {
                throw new DataValidationException(fieldName, DataValidationFailure.TimeSpanTooHigh, maxValue, fieldValue.Value);
            }
        }

        protected void ValidateChildCollection(string fieldName, bool isAdd)
        {
            if (isAdd)
            {
                return;
            }

            IList children = this.GetValue<IList>(fieldName);

            if (children != null && children.Count > 0)
            {
                throw new DataValidationException(fieldName, DataValidationFailure.ChildCollectionNotEmpty);
            }
        }

        protected static void ValidateNoneOrBoth(string field1Name, string field1Value, string field2Name, string field2Value)
        {
            if (string.IsNullOrEmpty(field1Value) == string.IsNullOrEmpty(field2Value))
            {
                return;
            }

            throw new DataValidationException(field1Name, field2Name, DataValidationFailure.NoneOrBoth);
        }

        protected static void ValidateBoolean(string fieldName, bool fieldValue, bool expectedValue)
        {
            if (fieldValue == expectedValue)
            {
                return;
            }

            throw new DataValidationException(fieldName, DataValidationFailure.IllegalValue, fieldValue);
        }

        #endregion
    }

}