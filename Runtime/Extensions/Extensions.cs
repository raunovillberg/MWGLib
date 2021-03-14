using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = System.Random;

namespace MWG
{
    public static class ArrayExtensions
    {
        /// Shuffles the array in place
        public static T[] Shuffle<T>(this T[] array)
        {
            //Knuth shuffle algorithm
            for (var t = 0; t < array.Length; t++)
            {
                var tmp = array[t];
                var r = UnityEngine.Random.Range(t, array.Length);
                array[t] = array[r];
                array[r] = tmp;
            }

            return array;
        }
    }

    public static class RandomExtensions
    {
        public static bool PercentageChance(this Random random, int chance, int max = 100)
        {
            if (max < 1)
                throw new InvalidOperationException($"{max} needs to be over 0!");
            
            return random.Next(0, 100) < max;
        }

        public static bool PercentageChance(this Random random, float chance, int max = 100)
        {
            if (max < 1)
                throw new InvalidOperationException($"{max} needs to be over 0!");
            
            return random.Next(0, max) < chance;
        }

        public static T GetEnum<T>(this Random random) where T : Enum
        {
            var val = Enum.GetValues(typeof(T));
            return (T) val.GetValue(random.Next(val.Length));
        }
    }

    public static class ColorExtensions
    {
        /// Multiplies each part of the Color (Red, Green & Blue - not Alpha) by a coefficent
        public static Color AtLightness(this Color color, float coef)
        {
            return new Color(color.r * coef, color.g * coef, color.b * coef, color.a);
        }

        /// <summary>
        /// Shorthand for
        /// <code>
        /// Color temp = colorProvider.color;
        /// temp.a = alpha;
        /// colorProvider.color = temp;
        /// </code>
        /// </summary>
        public static Color AtAlphaPercentage(this Color color, float alpha)
        {
            return new Color(color.r, color.g, color.b, alpha);
        }

        public static string ToHexString(this Color c)
        {
            return $"#{ColorUtility.ToHtmlStringRGB(c)}";
        }

        public static string ToRgbString(this Color c)
        {
            return $"RGB({c.r}, {c.g}, {c.b})"; 
        }

        public static Color FromHex(string hex)
        {
            ColorUtility.TryParseHtmlString(hex, out var returnColor);
            return returnColor;
        }

        public static Color Contrasting(this Color bg)
        {
            var bgDelta = Convert.ToInt32((bg.r * 255 * 0.299) + (bg.g * 255 * 0.587) + (bg.b * 255 * 0.114));

            var foreColor = (255 - bgDelta < 128) ? Color.black : Color.white;
            return foreColor;
        }
    }

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

    public static class GameObjectExtensions
    {
        public static void RemoveComponents<TComponent>(this GameObject obj, bool immediate = false)
        {
            foreach (var component in obj.GetComponents<TComponent>())
                RemoveComponentInternal(component, immediate);
        }

        public static void RemoveComponent<TComponent>(this GameObject obj, bool immediate = false)
        {
            RemoveComponentInternal(obj.GetComponent<TComponent>(), immediate);
        }

        public static void RemoveComponentInChildren<TComponent>(this GameObject obj, bool immediate = false)
        {
            RemoveComponentInternal(obj.GetComponentInChildren<TComponent>(), immediate);
        }

        public static void RemoveComponentsInChildren<TComponent>(this GameObject obj, bool immediate = false)
        {
            foreach (var component in obj.GetComponentsInChildren<TComponent>())
                RemoveComponentInternal(component, immediate);
        }

        private static void RemoveComponentInternal<TComponent>(TComponent component, bool immediate)
        {
            if (component == null)
            {
                Debug.LogWarning("RemoveComponent null component");
                return;
            }

            if (immediate)
                Object.DestroyImmediate(component as Object, true);
            else
                Object.Destroy(component as Object);
        }
    }

    public static class StringExtensions
    {
        public static bool EqualsPartially(this string text, string partialTextToLookFor)
        {
            return text.IndexOf(partialTextToLookFor, StringComparison.OrdinalIgnoreCase) != -1;
        }
    }
}