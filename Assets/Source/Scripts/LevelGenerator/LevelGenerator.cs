using System.Collections.Generic;
using Reflex.Attributes;
using UnityEngine;

namespace Faraway.TestGame
{
    public class LevelGenerator : MonoBehaviour
    {
        private const float GenerationAheadDistance = 40f;
        private const float MinimumDistanceBetweenPickups = 2f;
        private const float MaximumDistanceBetweenPickups = 10f;
        private const float MaximumHorizontalPickupOffset = 4.5f;
        private const float PickupHeight = 0.8f;

        private MainCamera _mainCamera;

        [SerializeField]
        private GameObject _jumpObstacle;
        [SerializeField]
        private List<LevelPickup> _levelPickups = new();

        private float _generatedDistance = 0;
        private float _totalPickupRoll;

        [Inject]
        public void Inject(MainCamera mainCamera)
        {
            _mainCamera = mainCamera;
        }

        private void Awake()
        {
            foreach (LevelPickup levelPickup in _levelPickups)
                _totalPickupRoll += levelPickup.SpawnChance;
        }

        private void Update()
        {
            while (_generatedDistance < _mainCamera.transform.position.z + GenerationAheadDistance)
            {
                float distanceFromLastPickup = Random.Range(MinimumDistanceBetweenPickups, MaximumDistanceBetweenPickups);

                // Select random pickup
                GameObject selectedPickup = null;
                float pickupRoll = Random.Range(0, _totalPickupRoll);
                float minimumRollToSelect = 0;
                foreach (LevelPickup levelPickup in _levelPickups)
                {
                    if (pickupRoll <= levelPickup.SpawnChance + minimumRollToSelect)
                    {
                        selectedPickup = levelPickup.Prefab;
                        break;
                    }

                    minimumRollToSelect += levelPickup.SpawnChance;
                }

                GameObject pickupGameObject = Instantiate(selectedPickup);
                pickupGameObject.transform.position = new Vector3(Random.Range(-MaximumHorizontalPickupOffset, MaximumHorizontalPickupOffset), PickupHeight, _generatedDistance + distanceFromLastPickup);

                _generatedDistance += distanceFromLastPickup;
            }
        }
    }
}
