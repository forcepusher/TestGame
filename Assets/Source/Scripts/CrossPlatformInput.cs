using System;
using System.Threading.Tasks;
using UnityEngine;

namespace Faraway.TestGame
{
    public class CrossPlatformInput : IInputSource, IDisposable
    {
        private const float MouseSensitivity = 100f;

        private bool _disposed = false;

        public CrossPlatformInput()
        {
            TickLoop();
        }

        public float HorizontalMovementDelta => _horizontalMovementDeltaTouch + _horizontalMovementDeltaMouse;
        public bool Jump => _jumpKeyboard || _jumpTouch;

        private float _horizontalMovementDeltaTouch;
        private float _horizontalMovementDeltaMouse => Input.GetAxisRaw("Mouse X") / Screen.width * MouseSensitivity;

        private bool _jumpTouch;
        private bool _jumpKeyboard => Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0);

        private async void TickLoop()
        {
            while (true)
            {
                await Task.Yield();

                if (_disposed)
                    return;

                if (Input.touchCount > 0)
                {
                    _jumpTouch = Input.touches[0].tapCount >= 1;
                    _horizontalMovementDeltaTouch = Input.touches[0].deltaPosition.x;
                }
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
