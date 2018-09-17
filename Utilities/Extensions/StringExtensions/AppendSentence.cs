namespace Utilities.Extensions.StringExtensions
{
    public static partial class StringExtensions
    {
        /// <summary>
        /// Append the second sentence to first sentence.
        /// First character of send sentence to lower case if the first sentence is an open
        /// sentence, i.e. does not end in an end of sentence punctuation mark.
        /// </summary>
        /// <param name="firstSentence"></param>
        /// <param name="secondSentence"></param>
        /// <returns></returns>
        public static string AppendSentence(this string firstSentence, string secondSentence)
        {
            switch (firstSentence[firstSentence.Length - 1])
            {
                case '.':
                case ':':
                case '?':
                case '!':
                    return $"{firstSentence} {secondSentence}";
                default:
                    return $"{firstSentence} {secondSentence[0].ToString().ToLower()}{secondSentence.Substring(1)}";
            }
        }
    }
}