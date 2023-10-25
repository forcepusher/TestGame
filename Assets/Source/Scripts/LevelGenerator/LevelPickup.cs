using System;
using UnityEngine;

namespace Faraway.TestGame
{
    [Serializable]
    public struct LevelPickup
    {
        public GameObject Prefab;
        public float SpawnChance;
    }
}
