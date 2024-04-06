using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectPac.StateMachineSystem
{
    /// <summary>
    /// Handles the dodge roll for the player.
    /// </summary>
    public class DodgeRoll : PlayerMovementState
    {
        private float maxRollTime     = 1f;
        private float currentRollTime = 0f;
        private float rollSpeed       = 7f;
        private Vector2 rollDir       = Vector2.zero; // Stores the direction the player will roll

        public DodgeRoll(PlayerLocomotion newOwner) : base(newOwner) {}

        public override void Enter()
        {
            owner.PlayerDamageable.SetInvulnerability(true);
            playerAnimator.SetBool("IsRolling", true);
            rollDir = inputController.MovementVector;
            currentRollTime = 0f;

#if UNITY_EDITOR
            Debug.LogFormat("DodgeRoll :: Dodge rolling direction is: {0}.", inputController.MovementVector);
#endif
        }

        public override void Exit()
        {
            owner.PlayerDamageable.SetInvulnerability(false);
            playerAnimator.SetBool("IsRolling", false);
            rollDir = Vector2.zero;
            currentRollTime = 0f;
        }

        public override void FixedUpdate(float fDT)
        {
            // Return to our normal movement state when we have rolled for too long
            if(currentRollTime >= maxRollTime)
            {
                owner.ChangeToState( 0 );
                return;
            }

            currentRollTime += fDT;
            Vector2 velocity = rollDir * rollSpeed;

            // Rigidbody.velocity keeps track of the framerate,
            // so we don't need to multiply by delta time
            rb2d.velocity = velocity;
        }

        protected override void PressedAttackButton()
        {
            // Break out of the dodge when the player presses attack
            if(inputController.PressedAttackThisFrame() == true)
                owner.ChangeToState( 0 );
        }
    }
}
