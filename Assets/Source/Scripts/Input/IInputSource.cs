namespace Faraway.TestGame
{
    /// <summary>
    /// Input source injected into a character as input strategy.
    /// </summary>
    public interface IInputSource
    {
        bool MoveLeft { get; }
        bool MoveRight { get; }
        bool Jump { get; }
    }
}
