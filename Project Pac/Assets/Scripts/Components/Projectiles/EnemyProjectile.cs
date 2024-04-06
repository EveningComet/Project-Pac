using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectPac.Components.Entities
{
    /// <summary>
    /// Projectile used by enemies that fire projectiles.
    /// </summary>
    /// <remarks>
    /// Created to prevent enemies from hurting each other for no reason.
    /// </remarks>
    public class EnemyProjectile : Projectile
    {
        private void OnTriggerEnter2D(Collider2D col)
        {
            // Don't hit other enemies or projectiles
            if(col.GetComponent<ProjectPac.StateMachineSystem.EnemyLocomotion>() != null
                || col.GetComponent<Projectile>() != null)
                return;

            var target = col.GetComponent<Damageable>();
            if(target != null)
            {
                target.TakeDamage( damage );
            }

            Destroy( this.gameObject );
        }
    }
}
