using UnityEngine;

namespace Faraway.TestGame
{
    public class FlyCoin : MonoBehaviour
    {
        [SerializeField]
        private float _duration = 10f;

        private void OnTriggerEnter(Collider enteredCollider)
        {
            IRunner runner = enteredCollider.GetComponent<IRunner>();
            if (runner != null)
                runner.AddEffect(new FlyCoinEffect(runner, _duration));
        }
    }
}
