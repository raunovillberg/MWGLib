using System;
using System.ComponentModel;

namespace MWG
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum value)
        {
            var type = value.GetType();
            var name = Enum.GetName(type, value);
            if (name == null)
                return "";
            var field = type.GetField(name);
            if (field == null)
                return name;
            
            if (Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attr)
                return attr.Description;

            return name;
        }
    }
}