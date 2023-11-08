namespace Faraway.TestGame
{
    public abstract class CoinEffect : IEffectBehavior
    {
        protected float ElapsedTime;
        public abstract int StackingIdentifier { get; }
        public abstract int Duration { get; }
        public bool OutOfTime => ElapsedTime >= Duration;

        public virtual void Start() { }

        public virtual void Tick(float deltaTime)
        {

        }

        public virtual void End() { }
    }
}
