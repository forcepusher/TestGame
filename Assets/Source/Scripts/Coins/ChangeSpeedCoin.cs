using UnityEngine;

namespace Faraway.TestGame
{
    /// <summary>
    /// Coin pickup. Creates <see cref="ChangeSpeedCoinEffect"/> and adds it to Effects.
    /// </summary>
    public class ChangeSpeedCoin : MonoBehaviour
    {
        [SerializeField]
        private float _duration = 10f;
        [SerializeField]
        private float _speedChange = 10f;

        private void OnTriggerEnter(Collider enteredCollider)
        {
            // IRunner is also an IEffectTarget
            IRunner runner = enteredCollider.GetComponent<IRunner>();
            if (runner != null)
            {
                runner.AddEffect(new ChangeSpeedCoinEffect(runner, _speedChange, _duration));
                Destroy(gameObject);
            }
        }
    }
}
