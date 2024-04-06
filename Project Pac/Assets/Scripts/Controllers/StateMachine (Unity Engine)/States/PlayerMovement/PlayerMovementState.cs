using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GeneralUnityEngineCode.StateMachineSystem;
using ProjectPac.PlayerControl;

namespace ProjectPac.StateMachineSystem
{
    /// <summary>
    /// A base class for a <see cref="State"/> that will control the player's movement.
    /// </summary>
    public abstract class PlayerMovementState : State
    {
        protected PlayerLocomotion owner          = null;
        protected InputController inputController = null;
        protected Rigidbody2D rb2d                = null;
        protected Animator playerAnimator         = null;

        public PlayerMovementState(PlayerLocomotion newOwner)
        {
            owner           = newOwner;
            rb2d            = newOwner.Rigidbody2d;
            inputController = newOwner.InputController;
            playerAnimator  = newOwner.PlayerAnimator;
        }

        /// <summary>
        /// Stuff that needs to be updated every update.
        /// </summary>
        public virtual void Update(float dT)
        {
            PressedDodgeButton();
            PressedAttackButton();
        }

        /// <summary>
        /// Stuff that needs to be updated every fixed update
        /// </summary>
        public virtual void FixedUpdate(float fDT) {}

        protected virtual void PressedDodgeButton() {}

        protected virtual void PressedAttackButton() {}
    }
}
