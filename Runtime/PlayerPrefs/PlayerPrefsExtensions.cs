namespace MWG
{
    public static class PlayerPrefsX
    {
        public static void SetBool(string name, bool booleanValue)
        {
            UnityEngine.PlayerPrefs.SetInt(name, booleanValue ? 1 : 0);
        }

        public static bool GetBool(string name, bool defaultValue)
        {
            return UnityEngine.PlayerPrefs.HasKey(name)
                ? UnityEngine.PlayerPrefs.GetInt(name) == 1
                : defaultValue;
        }
    }
}