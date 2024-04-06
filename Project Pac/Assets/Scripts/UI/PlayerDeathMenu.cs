using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProjectPac.GameControl.LevelControl;

namespace ProjectPac.UI
{
    /// <summary>
    /// Used to display a menu of options for the player when they die.
    /// </summary>
    public class PlayerDeathMenu : MonoBehaviour
    {
        /// <summary>
        /// The child game object storing our buttons.
        /// </summary>
        [SerializeField] private GameObject myButtonHolder = null;
        private LevelController levelController;

        private void Awake()
        {
            levelController = FindObjectOfType<LevelController>();
            levelController.OnPlayerDeath += OnPlayerDied;
            Hide();
        }

        private void OnDisable()
        {
            Hide();
            levelController.OnPlayerDeath -= OnPlayerDied;
        }

        private void OnPlayerDied()
        {
            // Display our menu
            Display();
        }

        private void Display()
        {
            myButtonHolder.SetActive(true);
        }

        private void Hide()
        {
            myButtonHolder.SetActive(false);
        }
    }
}
