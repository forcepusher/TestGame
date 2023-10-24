using Reflex.Attributes;
using UnityEngine;

namespace Faraway.TestGame
{
    public class LevelGenerator : MonoBehaviour
    {
        private const float GenerationAheadLength = 40f;
        private const float GenerationSegmentLength = 100f;
        private const float MinimumDistanceBetweenCoins = 0f;
        private const float MaximumDistanceBetweenCoins = 5f;
        private const float MaxmmumHorizontalCoinOffset = 4.5f;

        private MainCamera _mainCamera;

        [SerializeField]
        private FlyCoin _flyCoinPrefab;
        [SerializeField]
        private ChangeSpeedCoin _increaseSpeedCoinPrefab;
        [SerializeField]
        private ChangeSpeedCoin _reduceSpeedCoinPrefab;

        private float _generatedUntilDistance = 0;

        [Inject]
        public void Inject(MainCamera mainCamera)
        {
            _mainCamera = mainCamera;
        }

        private void Update()
        {
            while (_generatedUntilDistance < _mainCamera.transform.position.z + GenerationAheadLength)
            {
                
            }
        }
    }
}
