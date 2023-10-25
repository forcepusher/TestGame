using UnityEngine;

namespace Faraway.TestGame
{
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
