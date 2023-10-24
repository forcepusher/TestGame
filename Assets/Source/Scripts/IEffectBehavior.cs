namespace Faraway.TestGame
{
    public interface IEffectBehavior
    {
        void Tick(float deltaTime);

        bool HasEnded { get; }
    }
}
