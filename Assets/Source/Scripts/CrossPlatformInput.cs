using System;
using System.Threading.Tasks;
using UnityEngine;

namespace Faraway.TestGame
{
    public class CrossPlatformInput : IInputSource, IDisposable
    {
        private bool _disposed = false;

        public CrossPlatformInput()
        {
            TickLoop();
        }

        private async void TickLoop()
        {
            while (true)
            {
                await Task.Yield();

                if (_disposed)
                    return;
            }
        }

        public float HorizontalMovementDelta => throw new System.NotImplementedException();

        public bool Jump => throw new System.NotImplementedException();

        public void Dispose()
        {
            _disposed = true;
        }
    }
}
