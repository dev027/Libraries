namespace Utilities.Extensions.BooleanExtensions
{
    public static partial class BooleanExtensions
    {
        /// <summary>
        /// Defaults strings for other library routines
        /// </summary>
        /// <see cref="ToTrueFalse"></see>
        /// <see cref="ToYesNo"></see>
        private static class Defaults
        {
            public static string True = "True";
            public static string False = "False";
            public static string Yes = "Yes";
            public static string No = "No";
        }

        /// <summary>
        /// Override the default strings for other library routines
        /// </summary>
        /// <param name="trueValue">Text for True</param>
        /// <param name="falseValue">Text for False</param>
        /// <param name="yes">Text for Yes</param>
        /// <param name="no">Test for No</param>
        public static void SetDefaults(
            string trueValue = null,
            string falseValue = null,
            string yes = null,
            string no = null)
        {
            if (trueValue != null)
            {
                Defaults.True = trueValue;
            }

            if (falseValue != null)
            {
                Defaults.False = falseValue;
            }

            if (yes != null)
            {
                Defaults.Yes = yes;
            }

            if (no != null)
            {
                Defaults.No = no;
            }
        }
    }
}
