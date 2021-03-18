using System;
using System.Collections.Generic;

namespace MWG
{
    public static class IListExtensions
    {
        public static T Random<T>(this IList<T> list, Random random, int start = 0)
        {
            return list[random.Next(start, list.Count)];
        }

        public static T RemoveRandom<T>(this IList<T> list, Random random, int start = 0)
        {
            var index = random.Next(start, list.Count);
            var returnValue = list[index];
            list.RemoveAt(index);

            return returnValue;
        }

        public static T Last<T>(this IList<T> list)
        {
            return list[list.Count - 1];
        }

        public static int IndexOf<T>(this IList<T> list, T item)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (object.Equals(list[i], item))
                {
                    return i;
                }
            }

            return -1;
        }
    }
}