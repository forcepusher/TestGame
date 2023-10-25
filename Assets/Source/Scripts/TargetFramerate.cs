using UnityEngine;

namespace Faraway.TestGame
{
    public static class TargetFramerate
    {
        [RuntimeInitializeOnLoadMethod]
        public static void Initialize()
        {
            Application.targetFrameRate = 60;
        }
    }
}
