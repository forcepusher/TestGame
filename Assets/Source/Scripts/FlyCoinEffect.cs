namespace Faraway.TestGame
{
    public class FlyCoinEffect : IEffectBehavior
    {
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
            //if (_runner)
        }
    }
}
