using System;
using System.Collections.Generic;
using System.Linq;

namespace Utilities.Extensions.TypeExtensions
{
    public static partial class TypeExtensions
    {
        public static List<T> GetConstantsValues<T>(this Type type) where T : class
        {
            return GetConstants(type).Select(fi => fi.GetRawConstantValue() as T).ToList();
        }
    }
}