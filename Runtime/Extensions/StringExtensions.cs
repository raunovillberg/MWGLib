using System;

namespace MWG
{
    public static class StringExtensions
    {
        public static bool EqualsPartially(this string text, string partialTextToLookFor)
        {
            return text.IndexOf(partialTextToLookFor, StringComparison.OrdinalIgnoreCase) != -1;
        }
        
        /// Returns the String, prepending "start" - if needed.
        /// For example: StartingWith("line", "lia") returns "lialine"
        /// But StartingWith("line", "lin") returns "line"
        public static string StartingWith(this string line, string start)
        {
            return line.StartsWith(start) ? line : start + line;
        }

        /// Returns the String, appending "end" - if needed.
        /// For example: EndingWith("line", "lia") returns "linelia"
        /// But StartingWith("line", "ne") returns "line"
        public static string EndingWith(this string line, string end)
        {
            return line.EndsWith(end) ? line : line + end;
        }
        
        public static string ColoredByHex(this string text, string colorHex)
        {
            return colorHex.IsNullOrWhiteSpace()
                ? text
                : $"<color={colorHex}>{text}</color>";
        }

        public static bool IsNullOrWhiteSpace(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }
    }
}