using Reflex.Attributes;
using UnityEngine;

namespace Faraway.TestGame
{
    public class EnvironmentGenerator : MonoBehaviour
    {
        private const float GenerationAheadDistance = 100f;

        private GameObject _roadPiecePrefab;
        private GameObject _waterPiecePrefab;

        private float _lastRoadPieceZPosition;
        private float _lastWaterPieceZPosition;

        private MainCamera _mainCamera;

        [Inject]
        public void Inject(MainCamera mainCamera)
        {
            _mainCamera = mainCamera;
        }

        private void Update()
        {
            float generationDistance = _mainCamera.transform.position.z + GenerationAheadDistance;
            while (_lastRoadPieceZPosition < generationDistance)
            {

            }
        }
    }
}
