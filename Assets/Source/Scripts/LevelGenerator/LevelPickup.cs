using System;
using UnityEngine;

namespace Faraway.TestGame
{
    /// <summary>
    /// Structure used by <see cref="LevelGenerator"/> to set coin spawn chances.
    /// </summary>
    [Serializable]
    public struct LevelPickup
    {
        public GameObject Prefab;
        public float SpawnChance;
    }
}
