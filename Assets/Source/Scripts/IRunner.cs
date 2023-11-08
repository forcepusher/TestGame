using UnityEngine;

namespace Faraway.TestGame
{
    /// <summary>
    /// Interface for implementing pickup effects.<br/>
    /// Exposes required properties and methods for effects.
    /// </summary>
    public interface IRunner
    {
        Vector3 Velocity { get; set; }
        Vector3 Position { get; }
        void Move(Vector3 motion);
        bool IsGrounded { get; }
        void ChangeBehavior(IBehavior behavior);
        IInputSource InputSource { get; }
    }
}
