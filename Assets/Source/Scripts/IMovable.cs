using UnityEngine;

namespace Faraway.TestGame
{
    public interface IMovable
    {
        void Move(Vector2 motion);

        Vector2 Position { get; }
    }
}
