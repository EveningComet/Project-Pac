using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProjectPac.Components.Traps;

namespace ProjectPac.GameControl.LevelControl
{
    /// <summary>
    /// Object that holds data for a trap to spawn.
    /// </summary>
    [System.Serializable] // So we can edit in the inspector
    public class TrapSpawn
    {
        [SerializeField] private Trap trapToSpawn;
        public Trap TrapToSpawn { get { return trapToSpawn; } }
        [SerializeField] private Vector2 spawnPosition = Vector2.zero;
        public Vector2 SpawnPosition { get { return spawnPosition; } }
    }
}
