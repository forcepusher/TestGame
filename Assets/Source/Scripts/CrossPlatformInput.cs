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

        private float _horizontalMovementDeltaTouch = Input.touches[0].deltaPosition.x;
        private float _horizontalMovementDeltaMouse = Input.GetAxisRaw("Horizontal");

        private bool _jumpTouch = Input.touches[0].tapCount >= 1;
        private bool _jumpKeyboard = Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0);

        private async void TickLoop()
        {
            while (true)
            {
                await Task.Yield();

                if (_disposed)
                    return;


            }
        }

        private Vector2 AverageTouchPositionPixelCoordinates
        {
            get
            {
                Vector2 positionSum = Vector2.zero;
                foreach (Touch touches in Input.touches)
                    positionSum += touches.rawPosition;

                return positionSum / Input.touchCount;
            }
        }

        public void Dispose()
        {
            _disposed = true;
        }
    }
}
