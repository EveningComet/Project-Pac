using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProjectPac.Components.Entities;

namespace ProjectPac.Components.Collectibles
{
    /// <summary>
    /// Pickup that will heal the player.
    /// </summary>
    public class HealthPickup : Pickup
    {
        [SerializeField] private int healAmount = 1;

        private void OnTriggerEnter2D(Collider2D other)
        {
            // Don't heal enemies
            if(other.GetComponent<ProjectPac.StateMachineSystem.PlayerLocomotion>() == null)
                return;

            // Heal the player (since we know it's them at this point, we know they have a Damageable component)
            var playerToHeal = other.GetComponent<Damageable>();
            if(playerToHeal.CurrentHP == playerToHeal.MaxHP)
                return;

            ProjectPac.GameControl.Audio.AudioCaller.PlayClipAtPoint(pickupSound, transform.position);
            playerToHeal.HealDamage( healAmount );
            Destroy( gameObject );
        }
    }
}
