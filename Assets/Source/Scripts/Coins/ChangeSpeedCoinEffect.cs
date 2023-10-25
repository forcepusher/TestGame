using UnityEngine;

namespace Faraway.TestGame
{
    public class ChangeSpeedCoinEffect : IEffectBehavior
    {
        private readonly IRunner _runner;
        private readonly float _duration;
        private readonly float _speedAdjustment;

        private float _elapsedTime;

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
                _runner.Velocity = new Vector3(_runner.Velocity.x, _runner.Velocity.y, _runner.Velocity.z + _speedAdjustment);
            }

            if (wasActive && HasEnded)
                _runner.Velocity = new Vector3(_runner.Velocity.x, _runner.Velocity.y, _runner.Velocity.z - _speedAdjustment);
        }
    }
}