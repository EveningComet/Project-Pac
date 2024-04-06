using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProjectPac.Components.Traps;

namespace ProjectPac.Components.Entities
{
    /// <summary>
    /// Component for projectiles fired by a trap.
    /// </summary>
    /// <remarks>
    /// Created so that projectiles fired from a trap don't hit the thing that fired them.
    /// </remarks>
    public class TrapProjectile : Projectile
    {
        private void OnTriggerEnter2D(Collider2D col)
        {
            if(col.GetComponent<Trap>() != null)
                return;

            var target = col.GetComponent<Damageable>();
            if(target != null)
                target.TakeDamage( damage );
            Destroy( this.gameObject );
        }
    }
}
