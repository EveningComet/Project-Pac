using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GeneralUnityEngineCode.StateMachineSystem;
using ProjectPac.PlayerControl;
using ProjectPac.Components.Entities;

namespace ProjectPac.StateMachineSystem
{
    /// <summary>
    /// State machine in charge of the player's movement.
    /// </summary>
    public class PlayerLocomotion : StateMachine<PlayerMovementState>
    {
        public Rigidbody2D Rigidbody2d { get; private set; }
        public InputController InputController { get; private set; }

        /// <summary>
        /// The player's damageable component. Used as a quick and dirty way for us to let
        /// the player's dodge roll prevent damage.
        /// </summary>
        public Damageable PlayerDamageable { get; private set; }

        public Animator PlayerAnimator { get; private set; }

        /// <summary>
        /// Used as a quick and dirty way to let the relevant UI know that the player can dodge.
        /// </summary>
        public bool IsAbleToDodge { get; private set; }

        // Start is called before the first frame update
        private void Start()
        {
            Rigidbody2d      = GetComponent<Rigidbody2D>();
            InputController  = GetComponent<InputController>();
            PlayerDamageable = GetComponent<Damageable>();
            PlayerAnimator   = GetComponentInChildren<Animator>();

            // Create our needed movement states
            AddNewState( 0, new DefaultMovement(this) );
            AddNewState( 1, new DodgeRoll(this) );
            ChangeToState( 0 );
        }

        private void Update()
        {
            currentState.Update(Time.deltaTime);
        }

        private void FixedUpdate()
        {
            currentState.FixedUpdate(Time.fixedDeltaTime);
        }

        /// <summary>
        /// Set the value for whether or not the relevant UI should update.
        /// </summary>
        public void ToggleAbleToDodge(bool value)
        {
            IsAbleToDodge = value;
        }
    }
}
