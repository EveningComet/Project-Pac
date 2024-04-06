using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectPac.PlayerControl
{
    /// <summary>
    /// Meant to be attched to the player's animator (on a child object) to help us call certain animation events.
    /// </summary>
    public class PlayerAnimationEventHelper : MonoBehaviour
    {
        private PlayerAttackController myPAC;

        private void Start()
        {
            myPAC = GetComponentInParent<PlayerAttackController>();
        }

        public void OpenDamageCollider()
        {
            myPAC.OpenDamageCollider();
        }

        public void CloseDamageCollider()
        {
            myPAC.CloseDamageCollider();
        }
    }
}
