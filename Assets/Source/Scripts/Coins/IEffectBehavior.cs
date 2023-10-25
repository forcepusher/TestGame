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
        void Tick(float deltaTime);

        bool HasEnded { get; }
    }
}
