#if MWG_ASSERTIONS_ENABLED
using System;
#endif
using System.Diagnostics;
#if MWG_ASSERTIONS_ENABLED
using Debug = UnityEngine.Debug;
#endif

namespace MWG
{
    /// <summary>
    ///https://jacksondunstan.com/articles/4992 
    /// </summary>
    public static class MWGAssert
    {
        [Conditional("MWG_ASSERTIONS_ENABLED")]
        public static void SuperAssert(bool truth, string message)
        {
#if MWG_ASSERTIONS_ENABLED
        if (!truth)
        {
            Debugger.Break();
            Debug.LogError(message);
            throw new Exception(message);
        }
#endif
        }

        [Conditional("MWG_ASSERTIONS_ENABLED")]
        public static void Error(bool truth, string message)
        {
#if MWG_ASSERTIONS_ENABLED
        if (!truth)
        {
            Debug.LogError(message);
        }
#endif
        }
    }
}