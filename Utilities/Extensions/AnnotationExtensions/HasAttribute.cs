using System;
using System.Linq;
using System.Reflection;

namespace Utilities.Extensions.AnnotationExtensions
{
    public static partial class AnnotationExtensions
    {
        /// <summary>
        /// Return true if the name property has the specified attribute
        /// </summary>
        /// <typeparam name="T">Attribute type</typeparam>
        /// <param name="instance">Instance</param>
        /// <param name="propertyName">Property name</param>
        /// <returns>True if named property has attribute</returns>
        public static bool HasAttribute<T>(this object instance, string propertyName) where T : Attribute
        {
            Type attrType = typeof(T);
            PropertyInfo property = instance.GetType().GetProperty(propertyName);
            return (T)property?.GetCustomAttributes(attrType, inherit: false).FirstOrDefault() != null;
        }
    }
}