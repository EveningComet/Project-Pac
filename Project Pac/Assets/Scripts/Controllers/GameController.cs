using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProjectPac.GameControl.LevelControl;

namespace ProjectPac.GameControl
{
	/// <summary>
	/// Responsible for handling the game.
	/// </summary>
	[RequireComponent(typeof(LevelController))]
	public class GameController : MonoBehaviour
	{
		public LevelController LevelController     { get; private set; }
		public LoadingController LoadingController { get; private set; }

		private void Awake()
		{
			LevelController   = GetComponent<LevelController>();
			LoadingController = GetComponent<LoadingController>();
		}

		/// <summary>
		/// Turn off the game.
		/// </summary>
		public void QuitGame()
		{
#if UNITY_EDITOR
			// Turn off the editor if we're in it.
			UnityEditor.EditorApplication.isPlaying = false;
#endif
			Application.Quit();
		}
	}
}
