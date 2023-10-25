namespace Faraway.TestGame
{
    /// <summary>
    /// Used for adding pickup effects to implementing class.
    /// </summary>
    public interface IEffectTarget
    {
        void AddEffect(IEffectBehavior effectBehavior);
    }
}
