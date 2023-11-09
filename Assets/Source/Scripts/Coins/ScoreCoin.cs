using UnityEngine;

namespace Faraway.TestGame
{
    /// <summary>
    /// Coin pickup. Creates <see cref="ChangeSpeedCoinEffect"/> and adds it to Effects.
    /// </summary>
    public class ScoreCoin : MonoBehaviour
    {
        private void OnTriggerEnter(Collider enteredCollider)
        {
            // IRunner is also an IEffectTarget
            IRunner runner = enteredCollider.GetComponent<IRunner>();
            if (runner != null)
            {
                runner.IncreaseScore(1);
                Destroy(gameObject);
            }
        }
    }
}
