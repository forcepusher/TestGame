using UnityEngine;

namespace Faraway.TestGame
{
    /// <summary>
    /// Interface for implementing pickup effects.<br/>
    /// Exposes required properties and methods for effects.
    /// </summary>
    public interface IRunner : IEffectTarget
    {
        Vector3 Position { get; }
        Vector3 Velocity { get; set; }
        void Move(Vector3 motion);
        bool IsDead { get; set; }
    }
}
