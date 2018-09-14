using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Utilities.Extensions.TypeExtensions
{
    public static partial class TypeExtensions
    {
        public static List<FieldInfo> GetConstants(this Type type)
        {
            return type.GetFields(
                    BindingFlags.Public |               // Get Public fields
                    BindingFlags.Static |              // Get Static fields
                    BindingFlags.FlattenHierarchy)     // Get details fro base types as well
                .Where(fi => fi.IsLiteral)         // Value is written at compile time and not changeable
                .Where(fi => !fi.IsInitOnly)       // Field cannot be set in body of the constructor
                .ToList();

            // NOTE: readonly has IsLiteral = true AND IsInitOnly = true where as
            // const has IsLiteral = true AND IsInitOnly = false
        }
    }
}