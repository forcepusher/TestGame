using UnityEngine;

namespace Faraway.TestGame
{
    /// <summary>
    /// Effect from a <see cref="ChangeSpeedCoin"/>.<br/>
    /// </summary>
    /// <remarks>
    /// Effects from this coin can be stacked, each effect has its own duration.
    /// </remarks>
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

        public int Identifier { get; } = 1;

        public bool OutOfTime => _elapsedTime >= _duration;

        public void Tick(float deltaTime)
        {
            bool started = _elapsedTime == 0;

            _elapsedTime += deltaTime;

            if (started)
                _runner.Velocity = new Vector3(_runner.Velocity.x, _runner.Velocity.y, _runner.Velocity.z + _speedAdjustment);
        }

        public void End()
        {
            _runner.Velocity = new Vector3(_runner.Velocity.x, _runner.Velocity.y, _runner.Velocity.z - _speedAdjustment);
        }
    }
}
