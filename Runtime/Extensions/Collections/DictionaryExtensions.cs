using System;
using System.Collections.Generic;

namespace MWG
{
    public static class DictionaryExtensions
    {
        public static void Add<T>(this Dictionary<int, T> dict, int start, int end, T value)
        {
            if (start >= end)
                throw new InvalidOperationException($"start >= end for {start} & {end}");

            for (var i = start; i <= end; i++)
                dict.Add(i, value);
        }

        public static void Increment<T>(this Dictionary<T, int> dictionary, T key)
        {
            dictionary.TryGetValue(key, out var count);
            dictionary[key] = count + 1;
        }
    }
}