using System.Collections.Generic;
using Reflex.Attributes;
using UnityEngine;

namespace Faraway.TestGame
{
    public class LevelGenerator : MonoBehaviour
    {
        private const float GenerationAheadLength = 40f;
        private const float MinimumDistanceBetweenCoins = 2f;
        private const float MaximumDistanceBetweenCoins = 10f;
        private const float MaximumHorizontalCoinOffset = 4.5f;
        private const float CoinHeight = 0.8f;

        private MainCamera _mainCamera;

        [SerializeField]
        List<GameObject> _coinPrefabs = new();

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
                float distanceBetweenCoins = Random.Range(MinimumDistanceBetweenCoins, MaximumDistanceBetweenCoins);

                GameObject coinGameObject = Instantiate(_coinPrefabs[Random.Range(0, _coinPrefabs.Count)]);
                coinGameObject.transform.position = new Vector3(Random.Range(-MaximumHorizontalCoinOffset, MaximumHorizontalCoinOffset), CoinHeight, _generatedUntilDistance + distanceBetweenCoins);

                _generatedUntilDistance += distanceBetweenCoins;
            }
        }
    }
}
