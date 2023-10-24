namespace Faraway.TestGame
{
    public interface IEffectBehavior
    {
        void Tick();

        bool HasEnded { get; }
    }
}
