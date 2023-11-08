using UnityEngine;

namespace Faraway.TestGame
{
    /// <summary>
    /// Interface for implementing pickup effects.<br/>
    /// Exposes required properties and methods for effects.
    /// </summary>
    public interface IRunner
    {
        //Vector3 Position { get; }
        //bool IsDead { get; set; }

        void Move(Vector3 motion);
        bool IsGrounded { get; }
        void ChangeBehavior(IBehavior behavior);
        IInputSource InputSource { get; }
    }
}
