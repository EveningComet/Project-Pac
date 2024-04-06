using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectPac.Components.Entities
{
    public class PlayerProjectile : Projectile
    {
        /// <summary>
        /// Set the speed of this projectile. Mainly used by the player's weapon controller for throwing a weapon.
        /// </summary>
        public void SetSpeed(float newSpeed)
        {
            fireSpeed = newSpeed;
            rb = GetComponent<Rigidbody2D>();
            rb.velocity = transform.up * fireSpeed;
        }

        /// <summary>
        /// Set the damage of this projectile. Mainly used by the player's weapon controller for throwing a weapon.
        /// </summary>
        public void SetupDamage(int newDamage)
        {
            damage = newDamage;
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            // Don't hit the player!
            if(col.GetComponent<ProjectPac.StateMachineSystem.PlayerLocomotion>() != null)
                return;

            Damageable target = col.GetComponent<Damageable>();
            if(target != null)
            {
                target.TakeDamage( damage );
            }

            Destroy( this.gameObject );
        }
    }
}
