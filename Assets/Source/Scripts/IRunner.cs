using UnityEngine;

namespace Faraway.TestGame
{
    public interface IRunner : IEffectTarget
    {
        /// <remarks>
        /// Required for flying.
        /// </remarks>
        void Move(Vector3 motion);

        /// <remarks>
        /// Required for flying.
        /// </remarks>
        Vector3 Position { get; }

        /// <remarks>
        /// Required for reducing speed.<br/>
        /// Moving backwards as a speed reduction would be a crutch.
        /// </remarks>
        float Speed { get; set; }
    }
}
