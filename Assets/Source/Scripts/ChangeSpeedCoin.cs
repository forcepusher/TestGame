using UnityEngine;

namespace Faraway.TestGame
{
    public class ChangeSpeedCoin : MonoBehaviour
    {
        [SerializeField]
        private float _duration = 10f;
        [SerializeField]
        private float _speedChange = 10f;

        private void OnTriggerEnter(Collider enteredCollider)
        {
            IRunner runner = enteredCollider.GetComponent<IRunner>();
            if (runner != null)
            {
                runner.AddEffect(new ChangeSpeedCoinEffect(runner, _speedChange, _duration));
                Destroy(gameObject);
            }
        }
    }
}
