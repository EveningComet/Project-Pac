using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectPac.Components.Entities
{
	/// <summary>
	/// Component for an enemy that attacks with melee.
	/// </summary>
	public class MeleeAttacker : EnemyAttack
	{
		[SerializeField] private int attackDamage = 1;
		private MeleeDamageCollider meleeDamageCollider;

		private void Start()
		{
			meleeDamageCollider = GetComponentInChildren<MeleeDamageCollider>();
			meleeDamageCollider.SetupDamage(attackDamage);
		}

		protected override void ExecuteAttack()
		{
			// Tell the animator to execute the attack and it take things over from there.
			enemyAnimator.SetTrigger("MeleeAttack");
			locomotion.enabled = false;
		}

		/// <summary>
		/// Activate our damage collider. Meant to be called through the animator.
		/// </summary>
		public void OpenDamageCollider()
		{
			meleeDamageCollider.EnableDamageCollider();
		}

		/// <summary>
		/// Disable our damage collider. Meant to be called through the animator.
		/// </summary>
		public void CloseDamageCollider()
		{
			meleeDamageCollider.DisableDamageCollider();
			locomotion.enabled = true;
			enemyAnimator.ResetTrigger("MeleeAttack");
		}
	}
}
