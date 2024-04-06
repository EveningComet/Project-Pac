using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectPac.GameControl.LevelControl
{
	/// <summary>
	/// Trigger thing that tells anything that cares that the player has reached the current level's exit.
	/// </summary>
	public class LevelExit : MonoBehaviour
	{
		/* Used to tell anything that cares the player has entered the exit. */
		public delegate void PlayerEnteredExit();
		public event PlayerEnteredExit OnPlayerEntersExit;

		private void OnTriggerEnter2D(Collider2D col)
		{
			// Check if the player hit us
			var player = col.GetComponent<ProjectPac.StateMachineSystem.PlayerLocomotion>();
			if(player != null)
			{
#if UNITY_EDITOR
				Debug.Log("LevelExit :: Player has entered the exit.");
#endif
				// Keep the player from winning if they're dead
				if(player.GetComponent<ProjectPac.Components.Entities.Damageable>().CurrentHP <= 0)
					return;

				// If so, do the thing
				if(OnPlayerEntersExit != null)
					OnPlayerEntersExit();
			}
		}
	}
}
