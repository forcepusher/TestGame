namespace Faraway.TestGame
{
    public interface IInputSource
    {
        float HorizontalMovementDelta { get; }

        bool Jump { get; }
    }
}
