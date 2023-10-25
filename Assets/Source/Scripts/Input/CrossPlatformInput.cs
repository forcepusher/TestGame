using System;
using System.Threading.Tasks;
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
        private const float TouchMovementSensitivity = 10f;
        private const float TapTimeThreshold = 0.15f;

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

        private double _touchStartTime;
        private Vector2 _previousAverageTouchPosition;

        private async void TickLoop()
        {
            while (true)
            {
                await Task.Yield();

                if (_disposed)
                    return;

                _jumpTouch = false;
                _horizontalMovementDeltaTouch = 0f;

                if (Input.touchCount > 0)
                {
                    Vector2 averageTouchPosition = AverageTouchPositionNormalizedCoordinates;
                    Vector2 deltaPosition = averageTouchPosition - _previousAverageTouchPosition;
                    _horizontalMovementDeltaTouch = deltaPosition.x * TouchMovementSensitivity;
                    _previousAverageTouchPosition = averageTouchPosition;

                    if (Input.GetTouch(0).phase == TouchPhase.Began)
                        _touchStartTime = Time.realtimeSinceStartupAsDouble;

                    if (Input.GetTouch(0).phase == TouchPhase.Ended)
                        if (Time.realtimeSinceStartupAsDouble - _touchStartTime <= TapTimeThreshold)
                            _jumpTouch = true;
                }
            }
        }

        public void Dispose()
        {
            _disposed = true;
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

        private Vector2 AverageTouchPositionNormalizedCoordinates => AverageTouchPositionPixelCoordinates / new Vector2(Screen.width, Screen.height);
    }
}
