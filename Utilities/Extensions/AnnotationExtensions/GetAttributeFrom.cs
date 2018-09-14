using System;
using System.Linq;
using System.Reflection;

namespace Utilities.Extensions.AnnotationExtensions
{
    public static partial class AnnotationExtensions
    {
        /// <summary>
        /// Return the attributes from the named property on the current instance
        /// </summary>
        /// <typeparam name="T">Attribute type</typeparam>
        /// <param name="instance">Instance</param>
        /// <param name="propertyName">Property name</param>
        /// <returns>Attribute value or none if property or attribute do not exist</returns>
        public static T GetAttributeFrom<T>(this object instance, string propertyName) where T : Attribute
        {
            Type attrType = typeof(T);
            PropertyInfo property = instance.GetType().GetProperty(propertyName);
            return (T)property?.GetCustomAttributes(attrType, inherit: false).FirstOrDefault();
        }
    }
}