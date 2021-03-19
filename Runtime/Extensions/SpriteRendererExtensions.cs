using UnityEngine;

namespace MWG
{
    public static class SpriteRendererExtensions
    {
        public static void SetAlpha(this SpriteRenderer spriteRenderer, float alpha)
        {
            var temp = spriteRenderer.color;
            temp.a = alpha;
            spriteRenderer.color = temp;
        }
    }
}