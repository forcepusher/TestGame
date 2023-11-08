using UnityEngine;

namespace Faraway.TestGame
{
    public class SlowRunCoin : MonoBehaviour
    {
        private void OnTriggerEnter(Collider enteredCollider)
        {
            if (enteredCollider.TryGetComponent(out IRunner runner))
            {
                runner.ChangeBehavior(new SlowRunBehavior());
                Destroy(gameObject);
            }
        }
    }
}
