using System.Collections.Generic;
using UnityEngine;
using VContainer;

namespace Faraway.TestGame
{
    public class EnvironmentVegetationGenerator : MonoBehaviour
    {
        private const float GenerationAheadDistance = 200f;
        private const float HorizontalOffset = 5.3f;
        private const float SpacingMin = 3f;
        private const float SpacingMax = 20f;

        [SerializeField]
        private List<GameObject> _vegetationPieces;

        private float _lastPieceZPosition;
        private int _lastOffsetMultiplier = 1;

        private MainCamera _mainCamera;

        [Inject]
        public void Construct(MainCamera mainCamera)
        {
            _mainCamera = mainCamera;
        }

        private void Update()
        {
            float generationDistance = _mainCamera.transform.position.z + GenerationAheadDistance;

            while (_lastPieceZPosition < generationDistance)
            {
                GameObject piece = _vegetationPieces[Random.Range(0, _vegetationPieces.Count)];
                float spacing = Random.Range(SpacingMin, SpacingMax);
                Instantiate(piece, new Vector3(HorizontalOffset * _lastOffsetMultiplier, 0f, _lastPieceZPosition + spacing), Quaternion.identity);
                _lastPieceZPosition += spacing * 2;
                _lastOffsetMultiplier *= -1;
            }
        }
    }
}
