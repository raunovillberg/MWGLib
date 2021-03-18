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
}