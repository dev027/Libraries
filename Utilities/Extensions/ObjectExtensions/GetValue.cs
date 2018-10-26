using System;
using System.Reflection;

namespace Utilities.Extensions.ObjectExtensions
{
    // ReSharper disable once PartialTypeWithSinglePart
    public static partial class ObjectExtensions
    {
        public static T GetValue<T>(this object obj, string propertyName)
        {
            PropertyInfo propertyInfo = obj.GetType().GetProperty(propertyName);
            if (propertyInfo == null)
            {
                throw new ArgumentException($"Property {propertyName} does not exist",
                    nameof(propertyName));
            }
            return (T)propertyInfo.GetValue(obj);
        }
    }
}