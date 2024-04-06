using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProjectPac.PlayerControl;
using TMPro;

namespace ProjectPac.UI
{
    /// <summary>
    /// Displays how many hits are remaining in the player's current weapon.
    /// </summary>
    public class WeaponHitsRemainingDisplayer : MonoBehaviour
    {
        [SerializeField] private WeaponController myPWC = null;
        [SerializeField] private GameObject hitsRemainingTextGO;
        [SerializeField] private GameObject weaponSpriteGO;
        private TextMeshProUGUI displayText;
        private bool isAlreadyDisplaying = false;

        private void OnEnable()
        {
            displayText = hitsRemainingTextGO.GetComponent<TextMeshProUGUI>();

            // Sub to the event
            myPWC.OnHitsRemainingChanged += OnHitsRemainingChanged;
            OnHitsRemainingChanged(myPWC.HitsUntilWeaponBreaks);
        }

        private void OnDisable()
        {
            // Unsub from the event
            myPWC.OnHitsRemainingChanged -= OnHitsRemainingChanged;
        }

        private void OnHitsRemainingChanged(int numHitsLeft)
        {
            // Turn off the thing if there's no hits left
            if(numHitsLeft == 0)
            {
                isAlreadyDisplaying = false;
                weaponSpriteGO.SetActive( false );
                hitsRemainingTextGO.SetActive( false );
                return;
            }

            // Enable the relevant things to display
            if(isAlreadyDisplaying == false)
            {
                isAlreadyDisplaying = true;
                weaponSpriteGO.SetActive( true );
                hitsRemainingTextGO.SetActive( true );
            }

            // Display the relevant values left
            displayText.text = numHitsLeft.ToString();
        }
    }
}
