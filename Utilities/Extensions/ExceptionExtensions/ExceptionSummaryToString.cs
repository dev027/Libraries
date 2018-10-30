using System;

namespace Utilities.Extensions.ExceptionExtensions
{
    public static partial class ExceptionExtensions
    {
        public static string ExceptionSummaryToString(this Exception ex)
        {
            string description = $"{ex.GetType().Name}: {ex.Message}";

            if (ex.InnerException != null)
            {
                description += "|" + ex.InnerException.ExceptionSummaryToString();
            }

            return description;
        }
    }
}