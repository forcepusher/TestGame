using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BananaParty.TouchInput;
using UnityEngine;

namespace Faraway.TestGame
{
    /// <summary>
    /// It's an <see cref="IInputSource"/> implementing both Mouse and Touch controls.
    /// </summary>
    /// <remarks>
    /// Executes in an async/await loop utilizing <see cref="UnitySynchronizationContext"/>.
    /// </remarks>
    public class CrossPlatformInput : IInputSource, IDisposable
    {
        private const float MouseMovementSensitivity = 150f;
        //private const float TouchMovementSensitivity = 10f;

        private bool _disposed = false;

        public CrossPlatformInput()
        {
            Input.simulateMouseWithTouches = false;
            TickLoop();
        }

        public float HorizontalMovementDelta => _horizontalMovementDeltaTouch + _horizontalMovementDeltaMouse;
        public bool Jump => _jumpKeyboard || _jumpTouch;

        private float _horizontalMovementDeltaMouse => Input.GetAxisRaw("Mouse X") / Screen.width * MouseMovementSensitivity;
        private float _horizontalMovementDeltaTouch;

        private bool _jumpKeyboard => Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0);
        private bool _jumpTouch;

        private readonly Touchscreen _touchscreen = new();

        private readonly SwipeGesture _swipeUp = new(Vector2.up);
        private readonly SwipeGesture _swipeLeft = new(Vector2.left);
        private readonly SwipeGesture _swipeRight = new(Vector2.right);

        private async void TickLoop()
        {
            while (true)
            {
                await Task.Yield();

                if (_disposed)
                    return;

                _touchscreen.PollInput(Time.unscaledDeltaTime);

                while (_touchscreen.HasNewTouches)
                {
                    Finger finger = _touchscreen.GetNextNewTouch();
                    _swipeUp.AddFinger(finger);
                    _swipeLeft.AddFinger(finger);
                    _swipeRight.AddFinger(finger);
                }

                _swipeUp.PollInput();
                _swipeLeft.PollInput();
                _swipeRight.PollInput();

                _jumpTouch = _swipeUp.IsActuated;
            }
        }

        public void Dispose()
        {
            _disposed = true;
        }
    }
}
