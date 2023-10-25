using UnityEngine;

namespace Faraway.TestGame
{
    /// <summary>
    /// Kill prim obstacle that kills a character.
    /// </summary>
    public class JumpObstacle : MonoBehaviour
    {
        private void OnTriggerEnter(Collider otherCollider)
        {
            IRunner runner = otherCollider.GetComponent<IRunner>();
            if (runner != null)
                runner.IsDead = true;
        }
    }
}
