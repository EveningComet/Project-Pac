using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectPac.StateMachineSystem
{
    /// <summary>
    /// Handles the regular movement for the player.
    /// </summary>
    public class DefaultMovement : PlayerMovementState
    {
        private float moveSpeed = 6f;
        private float timeUntilDodgeRollIsReadyAgain     = 3f;
        private float currentTimeUntilNextDodgeRoll      = 0f;

        private bool isFirstTimeEnteringThisState   = true; // Quick and dirty way to let the player dodge roll at the start of the game

        public DefaultMovement(PlayerLocomotion newOwner) : base(newOwner) {}

        public override void Enter()
        {
            if(isFirstTimeEnteringThisState == true)
            {
            	currentTimeUntilNextDodgeRoll = timeUntilDodgeRollIsReadyAgain;
            	isFirstTimeEnteringThisState = false;
                owner.ToggleAbleToDodge( true );
            }
        }

        public override void Exit()
        {
       	    // Reset the counter
            currentTimeUntilNextDodgeRoll = 0f;
            owner.ToggleAbleToDodge( false );
        }

        public override void Update(float dT)
        {
            // Animate the player
            playerAnimator.SetFloat("AnimMoveX", inputController.MovementVector.x);
            playerAnimator.SetFloat("AnimMoveY", inputController.MovementVector.y);
            playerAnimator.SetFloat("AnimMoveMagnitude", inputController.MovementVector.magnitude);

            base.Update(dT);
        }

        public override void FixedUpdate(float fDT)
        {
            // Move the player
            Vector2 velocity = inputController.MovementVector * moveSpeed;
            rb2d.MovePosition(rb2d.position + velocity * fDT);

            // Tick the dodge roll timer
            currentTimeUntilNextDodgeRoll += fDT;
            currentTimeUntilNextDodgeRoll = Mathf.Clamp(currentTimeUntilNextDodgeRoll, 0f, timeUntilDodgeRollIsReadyAgain);
            if(currentTimeUntilNextDodgeRoll >= timeUntilDodgeRollIsReadyAgain)
                owner.ToggleAbleToDodge(true);
        }

        protected override void PressedDodgeButton()
        {
            // Switch to the dodge roll state
            if
            (
                inputController.PressedDodgeThisFrame() == true
                && inputController.MovementVector != Vector2.zero 
                && currentTimeUntilNextDodgeRoll >= timeUntilDodgeRollIsReadyAgain
            )
            	owner.ChangeToState( 1 );
        }
    }
}
