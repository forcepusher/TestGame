using System.Collections.Generic;
using Reflex.Attributes;
using UnityEngine;

namespace Faraway.TestGame
{
    public class EnvironmentVegetationGenerator : MonoBehaviour
    {
        private const float GenerationAheadDistance = 200f;

        [SerializeField]
        private List<VegetationPiece> _vegetationPieces;

        private float _lastPieceZPosition;

        private MainCamera _mainCamera;

        [Inject]
        public void Inject(MainCamera mainCamera)
        {
            _mainCamera = mainCamera;
        }

        private void Update()
        {
            float generationDistance = _mainCamera.transform.position.z + GenerationAheadDistance;

            while (_lastPieceZPosition < generationDistance)
            {
                VegetationPiece piece = _vegetationPieces[Random.Range(0, _vegetationPieces.Count)];
                float spacing = Random.Range(piece.SpacingMin, piece.SpacingMax);
                Instantiate(piece.Prefab, new Vector3(0f, 0f, _lastPieceZPosition + spacing), Quaternion.Euler(0f, Random.Range(0, 360f), 0f));
                _lastPieceZPosition += _lastPieceZPosition + spacing * 2f;
            }
        }
    }
}
