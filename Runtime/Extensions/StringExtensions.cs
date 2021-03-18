using System;

namespace MWG
{
    public static class StringExtensions
    {
        public static bool EqualsPartially(this string text, string partialTextToLookFor)
        {
            return text.IndexOf(partialTextToLookFor, StringComparison.OrdinalIgnoreCase) != -1;
        }
    }
}