using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProjectPac.Components.Entities;

namespace ProjectPac.PlayerControl
{
    /// <summary>
    /// Manages attacks for the player.
    /// </summary>
    public class PlayerAttackController : MonoBehaviour
    {
        [SerializeField] private GameObject weaponSwingEffect = null;

        /// <summary>
        /// What we're allowed to damage.
        /// </summary>
        [SerializeField] private LayerMask damageableMask;

        /// <summary>
        /// The parent of the attack point. Used for easy rotation.
        /// </summary>
        [SerializeField] private Transform attackPivotPoint;

        // TODO: we might still want the attack point for setting the attack effects.

        /// <summary>
        /// Cooldown to prevent the player from instantly performing attacks.
        /// </summary>
        private float attackCooldown = 0.5f;
        private float currentCooldownTime;
        private int damageToDeal = 1;

        private Camera cam;

        private InputController inputController;

        private Animator playerAnimator;

        private MeleeDamageCollider meleeDamageCollider;
        private WeaponController weaponController;

        private void Start()
        {
            cam = Camera.main;
            inputController = GetComponent<InputController>();
            weaponController = GetComponent<WeaponController>();
            meleeDamageCollider = GetComponentInChildren<MeleeDamageCollider>();
            playerAnimator = GetComponentInChildren<Animator>();

            // Sub to our damage collider's event
            meleeDamageCollider.OnHit += OnDamageColliderHitSomething;
        }

        private void OnDisable()
        {
            // Unsub from our damage collider's event for safety reasons
            meleeDamageCollider.OnHit -= OnDamageColliderHitSomething;
        }

        private void Update()
        {
            if(inputController.PressedAttackThisFrame() == true)
                Attack();

            else if(inputController.PressedThrowThisFrame() == true)
                ThrowWeapon();

        }

        private void FixedUpdate()
        {
            ProcessAttackCooldown(Time.fixedDeltaTime);
        }

        private void ProcessAttackCooldown(float dT)
        {
            currentCooldownTime += dT;
            Mathf.Clamp(currentCooldownTime, 0, attackCooldown);
        }

        /// <summary>
        /// Is the player allowed to attack at this moment in time?
        /// </summary>
        private bool MayAttack()
        {
            return currentCooldownTime >= attackCooldown;
        }

        private void ThrowWeapon()
        {
            if(weaponController.CurrentlyHasWeapon() == false || MayAttack() == false)
                return;

            // Throw the weapon
            SetAttackPivotPointRotation(true);
            weaponController.ThrowWeapon(attackPivotPoint);
        }

        /// <summary>
        /// Handle the player's attack.
        /// </summary>
        private void Attack()
        {
            if(weaponController.CurrentlyHasWeapon() == false || MayAttack() == false)
                return;

            SetAttackPivotPointRotation(false);

            // TODO: This is dirty. Clean this up when we can. WeaponController should keep track of this.
            meleeDamageCollider.SetupDamage(damageToDeal);

            // Trigger the animation
            playerAnimator.SetTrigger("Attack");

            // Reset the attack cooldown
            currentCooldownTime = 0f;
        }

        private void SetAttackPivotPointRotation(bool isThrowing)
        {
            // Get the mouse position
            Vector3 mousePos = cam.ScreenToWorldPoint(inputController.MousePosition);
            Vector3 targetDir = mousePos - transform.position;
            float angle = isThrowing == false ? Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg : Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg - 90f;
            attackPivotPoint.rotation = Quaternion.Euler(
                new Vector3(0f, 0f, angle)
            );

            // Set the relevant floats so our animator displays the correct animation
            playerAnimator.SetFloat("MouseX", targetDir.x);
            playerAnimator.SetFloat("MouseY", targetDir.y);
        }

        private void OnDamageColliderHitSomething()
        {
            // We hit something, so lower how many hits we have left
            weaponController.SubtractHitsRemaining(1);
        }

        #region Melee damage collider
        public void OpenDamageCollider()
        {
            meleeDamageCollider.EnableDamageCollider(weaponSwingEffect, 0.3f, attackPivotPoint);
        }

        public void CloseDamageCollider()
        {
            meleeDamageCollider.DisableDamageCollider();

            // Reset the animation
            playerAnimator.ResetTrigger("Attack");
        }
        #endregion
    }
}
