using UnityEngine;

namespace Faraway.TestGame
{
    /// <summary>
    /// Sets a desired target framerate.
    /// </summary>
    /// <remarks>
    /// Used mostly to achieve 60 FPS on Android devices.
    /// </remarks>
    public static class TargetFramerate
    {
        [RuntimeInitializeOnLoadMethod]
        public static void Initialize()
        {
            Application.targetFrameRate = 60;
        }
    }
}
