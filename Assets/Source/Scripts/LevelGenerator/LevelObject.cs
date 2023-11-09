using System;
using UnityEngine;

namespace Faraway.TestGame
{
    /// <summary>
    /// Structure used by <see cref="PickupAndObstacleGenerator"/> to set coin spawn chances.
    /// </summary>
    [Serializable]
    public class LevelObject
    {
        public GameObject Prefab;
        public int SpawnChance;
        public int MinimumInRow = 1;
        public int MaximumInRow = 1;
    }
}
