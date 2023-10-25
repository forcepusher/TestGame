namespace Faraway.TestGame
{
    /// <summary>
    /// Input source injected into Character as input strategy.
    /// </summary>
    public interface IInputSource
    {
        float HorizontalMovementDelta { get; }

        bool Jump { get; }
    }
}
