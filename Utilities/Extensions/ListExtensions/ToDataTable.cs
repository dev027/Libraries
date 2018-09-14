using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace Utilities.Extensions.ListExtensions
{
    public static partial class ListExtensions
    {
        /// <summary>
        /// Convert list to data table
        /// </summary>
        /// <typeparam name="T">List type</typeparam>
        /// <param name="list">List</param>
        /// <param name="propertyNames">List of property names to put into data table (default = all)</param>
        /// <returns>Data table</returns>
        public static DataTable ToDataTable<T>(this IEnumerable<T> list, IList<string> propertyNames = null)
        {
            // Flag copy all properties if list is null or empty
            bool allProperties = propertyNames == null || !propertyNames.Any();

            Type type = typeof(T);
            PropertyInfo[] properties = type.GetProperties();

            // Build data table columns
            DataTable dataTable = new DataTable();
            foreach (var info in properties)
            {
                // Only the columns that are required
                if (allProperties || propertyNames.Contains(info.Name))
                {
                    dataTable.Columns.Add(new DataColumn(
                        info.Name, 
                        Nullable.GetUnderlyingType(info.PropertyType) ?? info.PropertyType));
                }
            }

            // Build data table rows
            foreach (T entity in list)
            {
                object[] values = new object[properties.Length];
                for (int i = 0; i < properties.Length; i++)
                {
                    // Only the field for valid columns
                    if (allProperties || propertyNames.Contains(properties[i].Name))
                    {
                        values[i] = properties[i].GetValue(entity);
                    }
                }

                dataTable.Rows.Add(values);
            }

            return dataTable;
        }
    }
}