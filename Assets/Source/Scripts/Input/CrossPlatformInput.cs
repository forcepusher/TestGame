using System;
using System.Threading.Tasks;
using BananaParty.TouchInput;
using UnityEngine;
using VContainer.Unity;

namespace Faraway.TestGame
{
    /// <summary>
    /// It's an <see cref="IInputSource"/> implementing both Mouse and Touch controls.
    /// </summary>
    /// <remarks>
    /// Executes in an async/await loop utilizing <see cref="UnitySynchronizationContext"/>.
    /// </remarks>
    public class CrossPlatformInput : ITickable
    {
        public CrossPlatformInput()
        {
            Input.simulateMouseWithTouches = false;
        }

        public bool Jump => _jumpKeyboard || _jumpTouch;
        public bool MoveLeft => _moveLeftKeyboard || _moveLeftTouch;
        public bool MoveRight => _moveRightKeyboard || _moveRightTouch;

        private bool _moveLeftKeyboard => Input.GetKeyDown(KeyCode.A);
        private bool _moveLeftTouch;

        private bool _moveRightKeyboard => Input.GetKeyDown(KeyCode.D);
        private bool _moveRightTouch;

        private bool _jumpKeyboard => Input.GetButtonDown("Jump");
        private bool _jumpTouch;

        private readonly Touchscreen _touchscreen = new();

        private readonly SwipeGesture _swipeUp = new(Vector2.up);
        private readonly SwipeGesture _swipeLeft = new(Vector2.left);
        private readonly SwipeGesture _swipeRight = new(Vector2.right);

        public void Tick()
        {
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
            _moveLeftTouch = _swipeLeft.IsActuated;
            _moveRightTouch = _swipeRight.IsActuated;
        }
    }
}
