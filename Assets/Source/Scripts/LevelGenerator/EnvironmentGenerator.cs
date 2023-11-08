using Reflex.Attributes;
using UnityEngine;

namespace Faraway.TestGame
{
    public class EnvironmentGenerator : MonoBehaviour
    {
        private const float GenerationAheadDistance = 200f;

        [SerializeField]
        private EnvironmentPiece _roadPiece;
        [SerializeField]
        private EnvironmentPiece _waterPiece;

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
                Instantiate(_roadPiece.Prefab, new Vector3(0f, 0f, _lastRoadPieceZPosition), Quaternion.identity);
                _lastRoadPieceZPosition += _roadPiece.Distance;
            }

            while (_lastWaterPieceZPosition < generationDistance)
            {
                Instantiate(_waterPiece.Prefab, new Vector3(0f, 0f, _lastWaterPieceZPosition), Quaternion.identity);
                _lastWaterPieceZPosition += _waterPiece.Distance;
            }
        }
    }
}
