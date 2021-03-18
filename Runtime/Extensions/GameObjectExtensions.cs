using UnityEngine;

namespace MWG
{
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
}