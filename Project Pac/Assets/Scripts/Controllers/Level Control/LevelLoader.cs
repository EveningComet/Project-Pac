using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using ProjectPac.GameControl;
using ProjectPac.Components.Entities;
using ProjectPac.StateMachineSystem;

namespace ProjectPac.GameControl.LevelControl
{
    /// <summary>
    /// Responsible for the loading of levels for a <see cref="LevelController"/>
    /// </summary>
    public class LevelLoader : MonoBehaviour
    {
        private LoadingController loadingController;
        [SerializeField] private LevelExit levelExitPrefab; // Quick and dirty way to spawn the level exit

        private void Start()
        {
            loadingController = GetComponent<LoadingController>();
        }

        public void LoadLevel(LevelData newLevel, LevelController levelController)
        {
            // Don't load in a level while we're already loading
            if(loadingController.IsLoading == true)
            {
                return;
            }

            // Load in the relevant scene
			loadingController.LoadScene("Game"); // TODO: Probably want to cache the name of the scene where the levels are loaded into.

			StartCoroutine( LoadInLevel(newLevel, levelController) );
        }

        private IEnumerator LoadInLevel(LevelData newLevel, LevelController levelController)
		{
			// Wait for the LoadingController to finish loading in the new scene
			while(loadingController.IsLoading == true)
				yield return null;

			// It's done, now load in the stuff
			SetupLevel( newLevel, levelController );
		}

        private void SetupLevel(LevelData newLevel, LevelController levelController)
        {
            // Set the current level
            levelController.SetCurrentLevel( newLevel );

            // Put the player in the right place, and tell the level controller about them
			var p = (PlayerLocomotion)FindObjectOfType(typeof(PlayerLocomotion));
			if(p == null)
			{
#if UNITY_EDITOR
				Debug.LogError("LevelLoader:: We cannot find the pre-existing player in the scene! We're giving up.");
#endif
				return;
			}

			var player = p.transform.GetComponent<Damageable>();
			player.gameObject.transform.position = newLevel.PlayerSpawnPosition;
            levelController.SetMonitoredPlayer(player);

            // Spawn all the needed things for the level
            SpawnNeeded( newLevel, levelController );

            // Tell the A* Pathfinding Project to scan the level
			AstarPath.active.Scan();
        }


        private void SpawnNeeded(LevelData newLevel, LevelController levelController)
        {
            SpawnMap(newLevel);
            SpawnLevelExit(newLevel, levelController);
            SpawnEnemiesForLevel(newLevel);
            SpawnTrapsForLevel(newLevel);
            SpawnPickupsForLevel(newLevel);
        }

        /// <summary>
        /// Spawn the passed level for the passed data (which should just be the game object LevelData is attached to).
        /// </summary>
        private void SpawnMap(LevelData newLevel)
        {
            var lGO = GameObject.Instantiate(newLevel.gameObject);
			lGO.transform.SetParent( null );
        }

        private void SpawnLevelExit(LevelData newLevel, LevelController levelController)
        {
            // Spawn the exit
            var lExit = Instantiate
            (
                levelExitPrefab,
                newLevel.LevelExitSpawnPosition,
                Quaternion.identity
            );
            lExit.transform.SetParent( null );

            // Tell the level controller about it
            levelController.SetCurrentLevelExit( lExit );
        }

        /// <summary>
        /// Spawns any enemies for the passed level.
        /// </summary>
        private void SpawnEnemiesForLevel(LevelData newLevel)
        {
            int numEnemies = newLevel.Enemies.Count;
            for (int e = 0; e < numEnemies; e++)
            {
                var enemy = GameObject.Instantiate
                (
                    newLevel.Enemies[e].AssociatedEnemy,
                    newLevel.Enemies[e].EnemySpawnPoint,
                    Quaternion.identity
                );
                enemy.gameObject.transform.SetParent( null );
            }
        }

        private void SpawnTrapsForLevel(LevelData newLevel)
        {
            int numTraps = newLevel.Traps.Count;
            for (int t = 0; t < numTraps; t++)
            {
                var trap = GameObject.Instantiate
                (
                    newLevel.Traps[t].TrapToSpawn,
                    newLevel.Traps[t].SpawnPosition,
                    Quaternion.identity
                );
                trap.gameObject.transform.SetParent( null );
            }
        }

        private void SpawnPickupsForLevel(LevelData newLevel)
        {
            int numPickups = newLevel.Pickups.Count;
            for (int p = 0; p < numPickups; p++)
            {
                var pickup = GameObject.Instantiate
                (
                    newLevel.Pickups[p].PickupToSpawn,
                    newLevel.Pickups[p].SpawnPosition,
                    Quaternion.identity
                );
                pickup.gameObject.transform.SetParent( null );
            }
        }
    }
}
