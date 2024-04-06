using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ProjectPac.PlayerControl
{
    /// <summary>
    /// Keeps track of the player's inputs.
    /// </summary>
    public class InputController : MonoBehaviour
    {
        public Vector2 MovementVector { get; private set; }
        public Vector2 MousePosition { get; private set; }
        private PlayerInputActions playerInput;

        private void Awake()
        {
            // Activate the needed input stuff
            playerInput = new PlayerInputActions();
        }

        private void OnEnable()
        {
            playerInput.Enable();
        }

        private void OnDisable()
        {
            playerInput.Disable();
        }

        private void Update()
        {
            MovementVector = playerInput.CharacterControls.Movement.ReadValue<Vector2>();
            MousePosition  = playerInput.CharacterControls.Look.ReadValue<Vector2>();
        }

        /// <summary>
        /// Ask the Unity input system if the player has pressed the dodge button this frame.
        /// </summary>
        public bool PressedDodgeThisFrame()
        {
            return playerInput.CharacterControls.DodgeRoll.triggered;
        }

        /// <summary>
        /// Ask the Unity input system if the player has pressed the attack button this frame.
        /// </summary>
        public bool PressedAttackThisFrame()
        {
            return playerInput.CharacterControls.Attack.triggered;
        }

        /// <summary>
        /// Ask the Unity input system if the player has pressed the throw button this frame.
        /// </summary>
        public bool PressedThrowThisFrame()
        {
            return playerInput.CharacterControls.Throw.triggered;
        }
    }
}
