using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ProjectPac.GameControl;
using ProjectPac.GameControl.LevelControl;

namespace ProjectPac.UI
{
    /// <summary>
    /// Button responsible for loading to the main menu or telling the <see cref="LevelController"/> to load a level.
    /// </summary>
    public class GameControlButton : MonoBehaviour
    {
        [SerializeField] private bool startsFirstLevel     = false;
        [SerializeField] private bool restartsCurrentLevel = false;
        [SerializeField] private bool returnsToMainMenu    = false;
        private Button button;

        private void Awake()
        {
            button = GetComponent<Button>();

            // Find relevant things for this button
            LevelController lc = FindObjectOfType<LevelController>();
            GameController gc  = FindObjectOfType<GameController>();

            if(restartsCurrentLevel == true)
                button.onClick.AddListener(lc.RestartCurrentLevel);

            else if(startsFirstLevel == true)
                button.onClick.AddListener(lc.LoadFirstLevel);

            else if(returnsToMainMenu == true)
                button.onClick.AddListener(lc.ReturnToMainMenu);

            else
                button.onClick.AddListener(gc.QuitGame);
        }
    }
}
