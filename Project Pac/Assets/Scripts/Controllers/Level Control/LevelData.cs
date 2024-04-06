using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProjectPac.Components.Entities;

namespace ProjectPac.GameControl.LevelControl
{
    /// <summary>
    /// Stores information for a level. Meant to be attached to a game object storing the tilemap.
    /// </summary>
    public class LevelData : MonoBehaviour
    {
        [Header("Data")]
        [SerializeField] private Vector2 levelExitSpawnPosition = Vector2.zero;
        public Vector2 LevelExitSpawnPosition { get { return levelExitSpawnPosition; } }

        [SerializeField] private Vector2 playerSpawnPosition = Vector2.zero;
        public Vector2 PlayerSpawnPosition { get { return playerSpawnPosition; } }

        /// <summary>
        /// The level this level unlocks. If null, then then we can assume the player beat the game.
        /// </summary>
        [SerializeField] private LevelData levelUnlockedAfterWinning = null;
        public LevelData LevelUnlockedAfterWinning { get { return levelUnlockedAfterWinning; } }

        [Header("Pickups To Spawn")]
        /// <summmary>
        /// Pickups to spawn for this level, if any.
        /// </summary>
        [SerializeField] private List<PickupSpawn> pickups = new List<PickupSpawn>();
        public List<PickupSpawn> Pickups { get { return pickups; } }

        [Header("Enemies To Spawn")]
        /// <summary>
        /// The enemies associated with this level.
        /// </summary>
        [SerializeField] private List<EnemySpawn> enemies = new List<EnemySpawn>();
        public List<EnemySpawn> Enemies { get { return enemies; } }

        [Header("Traps")]
        /// <summary>
        /// Traps to spawn, if any.
        /// </summary>
        [SerializeField] private List<TrapSpawn> traps = new List<TrapSpawn>();
        public List<TrapSpawn> Traps { get { return traps;} }

#if UNITY_EDITOR
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.white;
            Gizmos.DrawWireSphere(levelExitSpawnPosition, 1f);
            Gizmos.DrawWireSphere(playerSpawnPosition, 1f);

            // Draw the enemy locations
            Gizmos.color = Color.red;
            for (int e = 0; e < enemies.Count; e++)
            {
                Gizmos.DrawWireSphere(enemies[e].EnemySpawnPoint, 0.5f);
            }
        }
#endif
    }
}
