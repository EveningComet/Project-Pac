using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectPac.Components.Entities
{
    /// <summary>
    /// Component meant to be attached to an enemy's graphics so that we can easily call specific animator events.
    /// </summary>
    public class EnemyAnimationEventHelper : MonoBehaviour
    {
        private MeleeAttacker meleeAttacker;
        private ProjectileAttacker projectileAttacker;

        private void Start()
        {
            meleeAttacker = transform.parent.GetComponent<MeleeAttacker>();
            projectileAttacker = transform.parent.GetComponent<ProjectileAttacker>();
        }

        #region ProjectileAttacker Animation Events
            public void FireProjectile()
            {
                projectileAttacker.FireProjectile();
            }
        #endregion

        #region MeleeAttacker Animation Events
            public void OpenDamageCollider()
            {
                meleeAttacker.OpenDamageCollider();
            }

            public void CloseDamageCollider()
            {
                meleeAttacker.CloseDamageCollider();
            }
        #endregion
    }
}
