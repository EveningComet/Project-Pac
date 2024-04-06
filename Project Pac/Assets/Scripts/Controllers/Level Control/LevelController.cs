using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using ProjectPac.GameControl;
using ProjectPac.Components.Entities;
using ProjectPac.StateMachineSystem; // So we can get the player

namespace ProjectPac.GameControl.LevelControl
{
	/// <summary>
	/// Responsible for handling the levels. Does not load them by itself!
	/// </summary>
	/// <remarks>
	/// Unless a more refined level management system is made, our levels are gone through as a linked list.
	/// Meaning, <see cref="LevelData"/> store a reference to another level.
	/// </remarks>
	public class LevelController : MonoBehaviour
	{
		#region Delegates / Events
			/// <summary>
			/// Used to tell anything that cares the player has died. Mainly used to open a menu that lets the player return
			/// to the main menu or restart the current level.
			/// </summary>
			public delegate void PlayerDeath();
			public event PlayerDeath OnPlayerDeath;
		#endregion
		/// <summary>
		/// Reference to the first level of the game.
		/// </summary>
		[SerializeField] private LevelData firstLevel = null;

		/// <summary>
		/// Our current level.
		/// </summary>
		private LevelData currentLevel = null;

		/// <summary>
		/// Reference to our player in the scene. Needed so that we can give the player
		/// an option to restart the current stage on death.
		/// </summary>
		private Damageable player;

		private LevelExit currentLevelExit = null;

		private LevelLoader levelLoader;

		/// <summary>
		/// Our loading controller. Mainly used to get us back to the main menu.
		/// </summary>
		private LoadingController loadingController;

		private void Start()
		{
			levelLoader = GetComponent<LevelLoader>();
			loadingController = GetComponent<LoadingController>();
		}

		private void OnDisable()
		{
			// Unsub from our events for safety reasons
			if(currentLevelExit != null)
				currentLevelExit.OnPlayerEntersExit -= OnPlayerEntersExit;

			if(player != null)
				player.OnIAmDead -= OnPlayerDied;

		}

		/// <summary>
		/// Load the first level in the game. Meant to be called from the main menu.
		/// </summary>
		public void LoadFirstLevel()
		{
			levelLoader.LoadLevel( firstLevel, this );
		}

		public void SetCurrentLevelExit(LevelExit newExit)
		{
			currentLevelExit = newExit;

			// Subscribe to our level exit's event
			currentLevelExit = newExit;
			currentLevelExit.OnPlayerEntersExit += OnPlayerEntersExit;
		}

		public void SetMonitoredPlayer(Damageable playerToMonitor)
		{
			player = playerToMonitor;
			player.OnIAmDead += OnPlayerDied;
		}

		public void SetCurrentLevel(LevelData newLevel)
		{
			currentLevel = newLevel;
		}

		public void RestartCurrentLevel()
		{
			levelLoader.LoadLevel( currentLevel, this );
		}

		public void ReturnToMainMenu()
		{
			loadingController.LoadScene("Main Menu");
		}

		private void OnPlayerEntersExit()
		{
#if UNITY_EDITOR
			Debug.LogWarning("LevelController :: We know that the player has entered the exit for the current level. Doing the relevant work now.");
#endif

			// Unsub from the current level exit event
			currentLevelExit.OnPlayerEntersExit -= OnPlayerEntersExit;

			// Tell anyone that cares the level is done

			// Destroy the current environment

			// Load in the next level (if there is one)
			if(currentLevel.LevelUnlockedAfterWinning != null)
			{
				// Load the next level
				levelLoader.LoadLevel( currentLevel.LevelUnlockedAfterWinning, this );
			}

			// We don't have one, so we can assume the player beat the game!
			else
			{
				loadingController.LoadScene("Main Menu");
			}
		}

		private void OnPlayerDied(Damageable playreToMonitor)
		{
			// Unsub for safety
			player.OnIAmDead -= OnPlayerDied;
			player = null;

			// Tell any listeners that the player is dead
			if(OnPlayerDeath != null)
				OnPlayerDeath();
		}
	}
}
