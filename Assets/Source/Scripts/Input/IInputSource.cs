namespace Faraway.TestGame
{
    /// <summary>
    /// Input source injected into a character as input strategy.
    /// </summary>
    public interface IInputSource
    {
        float HorizontalMovementDelta { get; }

        bool Jump { get; }
    }
}
