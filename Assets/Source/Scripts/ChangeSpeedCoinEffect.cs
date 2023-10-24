using UnityEngine;

namespace Faraway.TestGame
{
    public class ChangeSpeedCoinEffect : IEffectBehavior
    {
        private const float MinimalSpeed = 3f;
        private const float MaximalSpeed = 40f;

        private readonly IRunner _runner;
        private readonly float _duration;
        private readonly float _speedAdjustment;

        private float _elapsedTime;
        private float _actualSpeedAdjustment;

        public ChangeSpeedCoinEffect(IRunner runner, float speedAdjustment, float duration)
        {
            _runner = runner;
            _duration = duration;
            _speedAdjustment = speedAdjustment;
        }

        public bool HasEnded => _elapsedTime >= _duration;

        public void Tick(float deltaTime)
        {
            bool wasActive = !HasEnded;
            bool started = _elapsedTime == 0;

            _elapsedTime += deltaTime;

            if (started)
            {
                _actualSpeedAdjustment = _speedAdjustment;

                if (_runner.Velocity.z + _actualSpeedAdjustment < MinimalSpeed)
                    _actualSpeedAdjustment = MinimalSpeed - _runner.Velocity.z;

                if (_runner.Velocity.z + _actualSpeedAdjustment > MaximalSpeed)
                    _actualSpeedAdjustment = MaximalSpeed - _runner.Velocity.z;

                _runner.Velocity = new Vector3(0f, 0f, _runner.Velocity.z + _actualSpeedAdjustment);
            }

            if (wasActive && HasEnded)
                _runner.Velocity = new Vector3(0f, 0f, _runner.Velocity.z - _actualSpeedAdjustment);
        }
    }
}
