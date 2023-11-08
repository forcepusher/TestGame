namespace Faraway.TestGame
{
    /// <summary>
    /// Interface for executing and maintaining effect behaviors.<br/>
    /// </summary>
    /// <remarks>
    /// Implemented by effect classes such as <see cref="ChangeSpeedCoinEffect"/> and <see cref="FlyCoinEffect"/>.
    /// </remarks>
    public interface IEffectBehavior
    {
        int StackingIdentifier { get; }
        bool OutOfTime { get; }
        void Start();
        void Tick(float deltaTime);
        void End();
    }
}
