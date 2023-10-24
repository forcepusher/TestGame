using UnityEngine;

namespace Faraway.TestGame
{
    public class FlyCoinEffect : IEffectBehavior
    {
        private const float FlyHeight = 4f;

        private readonly IRunner _runner;
        private readonly float _duration;

        private float _elapsedTime;

        public FlyCoinEffect(IRunner runner, float duration)
        {
            _runner = runner;
            _duration = duration;
        }

        public bool HasEnded => _elapsedTime >= _duration;

        public void Tick(float deltaTime)
        {
            _elapsedTime += deltaTime;

            _runner.Velocity = new Vector3(_runner.Velocity.x, 0f, _runner.Velocity.z);
            float distanceToFlyHeight = FlyHeight - _runner.Position.y;
            _runner.Move(new Vector3(0f, distanceToFlyHeight, 0f));

            Debug.Log(_elapsedTime);
        }
    }
}
