using UnityEngine;

namespace Faraway.TestGame
{
    public class SprintRunCoin : MonoBehaviour
    {
        private void OnTriggerEnter(Collider enteredCollider)
        {
            if (enteredCollider.TryGetComponent(out IRunner runner))
            {
                runner.ChangeBehavior(new SprintRunBehavior());
                Destroy(gameObject);
            }
        }
    }
}
