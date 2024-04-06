using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProjectPac.StateMachineSystem;

namespace ProjectPac.UI
{
    /// <summary>
    /// Displays whether or not a player is able to dodge.
    /// </summary>
    public class DodgeRollUIDisplayer : MonoBehaviour
    {
        [SerializeField] private PlayerLocomotion monitoredPlayer;
        [SerializeField] private GameObject objectToDisplay;

        /// <summary>
        /// Used to prevent modifying the UI when it does not need to be updated.
        /// </summary>
        private bool isAlreadyDisplaying = true;

        private void FixedUpdate()
        {
            if(monitoredPlayer.IsAbleToDodge == true && isAlreadyDisplaying == false)
            {
                objectToDisplay.gameObject.SetActive( true );
                isAlreadyDisplaying = true;
            }

            else if(monitoredPlayer.IsAbleToDodge == false && isAlreadyDisplaying == true)
            {
                objectToDisplay.gameObject.SetActive( false );
                isAlreadyDisplaying = false;
            }
        }

    }
}
