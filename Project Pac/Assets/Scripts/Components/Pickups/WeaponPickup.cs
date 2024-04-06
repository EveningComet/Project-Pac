using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProjectPac.PlayerControl;

namespace ProjectPac.Components.Collectibles
{
    /// <summary>
    /// A weapon that can be picked up by the player.
    /// </summary>
    /// <remarks>
    /// At the time of the original creation of this script, I didn't see myself making
    /// any other kind of collectable. In the case more are desired, have this inherit
    /// from a generic Pickup class.
    /// </remarks>
    public class WeaponPickup : Pickup
    {
        /// <summary>
        /// How many times this weapon may hit something before breaking.
        /// </summary>
        [SerializeField] private int maxHitCases = 5;

        /// <summary>
        /// Returns the value for how many things this weapon may hit before breaking.
        /// </summary>
        public int MaxHitCases { get { return maxHitCases; } }

        private void OnTriggerEnter2D(Collider2D other)
        {
            // If the player colliders with us, add us to them if they don't already have a weapon
            WeaponController pWC = other.GetComponent<WeaponController>();
            if(pWC != null)
            {
                ProjectPac.GameControl.Audio.AudioCaller.PlayClipAtPoint(pickupSound, transform.position);
                if(pWC.CurrentlyHasWeapon() == true)
                    return;

                pWC.OnWeaponPickup(maxHitCases, gameObject);
                Destroy(gameObject);
            }
        }
    }
}
