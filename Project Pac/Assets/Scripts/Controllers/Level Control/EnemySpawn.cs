using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProjectPac.Components.Entities;

namespace ProjectPac.GameControl.LevelControl
{
    /// <summary>
    /// Object that holds data for an enemy to spawn.
    /// </summary>
    [System.Serializable] // Allows us to edit this in the inspector
    public class EnemySpawn
    {
        /// <summary>
        /// The enemy this object will spawn.
        /// </summary>
        [SerializeField] private EnemyAttack associatedEnemy;
        public EnemyAttack AssociatedEnemy { get { return associatedEnemy;} }

        /// <summary>
        /// Position in the game world where this enemy will spawn.
        /// </summary>
        [SerializeField] private Vector2 enemySpawnPoint = Vector2.zero;
        public Vector2 EnemySpawnPoint { get { return enemySpawnPoint; } }

        /// <summary>
        /// Constructor for taking an enemy to spawn (in case it wasn't set inside the inspector).
        /// </summary>
        public EnemySpawn(EnemyAttack enemyData, Vector2 spawnPoint)
        {
            associatedEnemy = enemyData;
            enemySpawnPoint = spawnPoint;
        }
    }
}
