using UnityEngine;
using ProjectPac.Components.Collectibles;

namespace ProjectPac.GameControl.LevelControl
{
    /// <summary>
    /// Object that holds data for a pickup in a level.
    /// </summary>
    [System.Serializable]
    public class PickupSpawn
    {
        [SerializeField] private Pickup pickupToSpawn;
        public Pickup PickupToSpawn { get { return pickupToSpawn; } }
        [SerializeField] private Vector2 spawnPosition = Vector2.zero;
        public Vector2 SpawnPosition { get { return spawnPosition; } }
    }
}
