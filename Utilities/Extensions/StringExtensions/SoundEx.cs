using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Utilities.Extensions.StringExtensions
{
    public static partial class StringExtensions
    {
        /// <summary>
        /// Return rhe 4-character SoundEx code for a string
        /// </summary>
        /// <param name="word">Word to get SoundEx code for</param>
        /// <returns>SoundEx code</returns>
        public static string SoundEx(this string word)
        {
            const int maxSoundExCodeLength = 4;

            StringBuilder soundExCode = new StringBuilder();
            bool previousWasHorW = false;

            // Cope if null. Convert to uppercase and string white space
            string cleanWord = Regex.Replace(
                word?.ToUpper() ?? string.Empty,
                @"[^\w\s]",
                string.Empty);

            // Empty string => return "0000"
            if (string.IsNullOrEmpty(cleanWord))
                return string.Empty.PadRight(maxSoundExCodeLength, '0');

            soundExCode.Append(cleanWord.First());

            for (int i = 1; i < cleanWord.Length; i++)
            {
                var numberCharForCurrentLetter =
                    GetCharNumberForLetter(cleanWord[i]);

                if (i == 1 &&
                    numberCharForCurrentLetter ==
                    GetCharNumberForLetter(soundExCode[0]))
                    continue;

                if (soundExCode.Length > 2 && previousWasHorW &&
                    numberCharForCurrentLetter ==
                    soundExCode[soundExCode.Length - 2])
                    continue;

                if (soundExCode.Length > 0 &&
                    numberCharForCurrentLetter ==
                    soundExCode[soundExCode.Length - 1])
                    continue;

                soundExCode.Append(numberCharForCurrentLetter);

                previousWasHorW = "HW".Contains(cleanWord[i]);
            }

            return soundExCode
                .Replace("0", string.Empty)
                .ToString()
                .PadRight(maxSoundExCodeLength, '0')
                .Substring(0, maxSoundExCodeLength);
        }

        private static char GetCharNumberForLetter(char letter)
        {
            if ("BFPV".Contains(letter)) return '1';
            if ("CGJKQSXZ".Contains(letter)) return '2';
            if ("DT".Contains(letter)) return '3';
            if ('L' == letter) return '4';
            if ("MN".Contains(letter)) return '5';
            if ('R' == letter) return '6';

            return '0';
        }
    }
}