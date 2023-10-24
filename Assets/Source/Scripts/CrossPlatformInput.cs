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

        public float HorizontalMovementDelta => _horizontalMovementDeltaTouch + _horizontalMovementDeltaMouse;
        public bool Jump => _jumpKeyboard || _jumpTouch;

        private float _horizontalMovementDeltaTouch;
        private float _horizontalMovementDeltaMouse;

        private bool _jumpTouch;
        private bool _jumpKeyboard = Input.GetButtonDown("Jump");

        private async void TickLoop()
        {
            while (true)
            {
                await Task.Yield();

                if (_disposed)
                    return;
            }
        }

        

        

        public void Dispose()
        {
            _disposed = true;
        }
    }
}
