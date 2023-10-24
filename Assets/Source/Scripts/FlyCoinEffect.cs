using UnityEngine;

namespace Faraway.TestGame
{
    public class FlyCoinEffect : IEffectBehavior
    {
        private const float FlyHeight = 3f;
        private const float FlyTweenVelocity = 40f;

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
            if (_runner.Position.y < FlyHeight)
                _runner.Move(new Vector3(0f, FlyTweenVelocity * deltaTime, 0f));

            Debug.Log("MOVEWFEJWLFIJEWL");

            _elapsedTime += deltaTime;
        }
    }
}
