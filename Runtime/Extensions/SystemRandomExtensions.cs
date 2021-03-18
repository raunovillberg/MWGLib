using System;

namespace MWG
{
    public static class SystemRandomExtensions
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
}