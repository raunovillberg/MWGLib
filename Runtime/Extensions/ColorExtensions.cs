using System;
using UnityEngine;

namespace MWG
{
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
}