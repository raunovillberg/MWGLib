using System;
using System.Collections.Generic;

namespace MWG
{
    public static class IReadOnlyListExtensions
    {
        public static T RandomReadOnly<T>(this IReadOnlyList<T> list, Random random, int start = 0)
        {
            return list[random.Next(start, list.Count)];
        }

        public static bool IsNullOrEmptyReadOnly<T>(this IReadOnlyList<T> collection)
        {
            return collection == null || collection.Count <= 0;
        }
    }
}