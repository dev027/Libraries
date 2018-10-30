using System;
using System.Text;

namespace Utilities.Extensions.ExceptionExtensions
{
    public static partial class ExceptionExtensions
    {
        public static string ExceptionToString(
            this Exception ex,
            Action<StringBuilder> customFieldsFormatterAction)
        {
            StringBuilder description = new StringBuilder();
            description.AppendFormat($"{ex.GetType().Name}: {ex.Message}");

            customFieldsFormatterAction?.Invoke(description);

            if (ex.InnerException != null)
            {
                description.AppendFormat($" ---> {ex.InnerException}");
                description.AppendFormat(
                    "{0}   --- End of inner exception stack trace ---{0}",
                    Environment.NewLine);
            }

            description.Append(ex.StackTrace);

            return description.ToString();
        }
    }
}