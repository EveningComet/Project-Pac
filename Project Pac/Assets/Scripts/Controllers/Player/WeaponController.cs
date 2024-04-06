using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProjectPac.Components.Collectibles;
using ProjectPac.Components.Entities;

namespace ProjectPac.PlayerControl
{
    /// <summary>
    /// Manages a player's weapon pickup.
    /// </summary>
    public class WeaponController : MonoBehaviour
    {
        #region Delegate/Event
            public delegate void HitsRemainingChanged(int hitsLeft);
            public event HitsRemainingChanged OnHitsRemainingChanged;
        #endregion

        /// <summary>
        /// How many more things the player may hit until their current weapon breaks.
        /// </summary>
        public int HitsUntilWeaponBreaks { get; private set; }

        /// <summary>
        /// Stores a copy of our current weapon so we can keep track of it for throwing.
        /// </summary>
        public GameObject CurrentWeapon { get; private set; }

        private float weaponThrowSpeed = 20f;

        /// <summary>
        /// Pickup the passed weapon, reading how many times it can hit something before breaking,
        /// and the object itself for reasons.
        /// </summary>
        public void OnWeaponPickup(int hitCases, GameObject pickupGO)
        {
            HitsUntilWeaponBreaks = hitCases;

            // Create a copy of the pickup and store it
            CurrentWeapon = Instantiate(pickupGO);
            CurrentWeapon.SetActive( false );

            if(OnHitsRemainingChanged != null)
                OnHitsRemainingChanged( HitsUntilWeaponBreaks );
        }

        /// <summary>
        /// Throw our current weapon, if we have one. Passed transform is so we can make the weapon face correctly.
        /// Remember there are no safety checks!
        /// </summary>
        public void ThrowWeapon(Transform t)
        {
            // TODO: Clean this up somehow. Maybe the weapon pickup script can keep track of the relevant components such as the player project class.
            var spawnedThrownWeapon = Instantiate(CurrentWeapon, t.position, t.rotation);
            spawnedThrownWeapon.transform.SetParent(null);
            spawnedThrownWeapon.AddComponent<PlayerProjectile>().SetSpeed( weaponThrowSpeed );
            Destroy( spawnedThrownWeapon.GetComponent<WeaponPickup>() );
            spawnedThrownWeapon.SetActive(true);
            ResetTrackedWeaponValues();
        }

        public void SubtractHitsRemaining(int subtractValue)
        {
            HitsUntilWeaponBreaks -= subtractValue;

            // Notify the relevant UI about our remaining hits
            if(OnHitsRemainingChanged != null)
                OnHitsRemainingChanged( HitsUntilWeaponBreaks );

            // Check if we need to break our weapon
            if(HitsUntilWeaponBreaks <= 0)
            {
                CurrentWeapon = null;
                HitsUntilWeaponBreaks = 0;
            }
        }

        /// <summary>
        /// If the hits remaining are > 0, we know the player has a weapon.
        /// </summary>
        public bool CurrentlyHasWeapon()
        {
            return HitsUntilWeaponBreaks > 0;
        }

        /// <summary>
        /// Quickly reset the tracked values related to the current weapon.
        /// </summary>
        public void ResetTrackedWeaponValues()
        {
            HitsUntilWeaponBreaks = 0;
            if(OnHitsRemainingChanged != null)
                OnHitsRemainingChanged( HitsUntilWeaponBreaks );

            Destroy(CurrentWeapon);
            CurrentWeapon = null;
        }
    }
}
