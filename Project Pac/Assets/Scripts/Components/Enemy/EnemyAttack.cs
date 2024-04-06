using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProjectPac.StateMachineSystem;

namespace ProjectPac.Components.Entities
{
	/// <summary>
	/// Base class for an enemy's attack type.
	/// </summary>
	/// <remarks>
	/// For better performance, it's a good idea to make this a state machine.
	/// </remarks>
	public abstract class EnemyAttack : MonoBehaviour
	{
		[Header("Enemy Attack Stats")]
		/// <summary>
		/// How close this enemy must get to a target in order to attack and start the cooldown for their attack.
		/// </summary>
		[SerializeField] protected float attackRadius = 5f;

		/// <summary>
	    /// How often does this enemy attack (in seconds)?
	    /// </summary>
		[SerializeField] protected float attackRate = 2f;
		protected float currentTimeUntilNextAttack  = 0f;

		/// <summary>
		/// Reference to the attached enemy's movement state machine. Mainly used to get their target easily.
		/// </summary>
		protected EnemyLocomotion locomotion;

		protected Animator enemyAnimator;

		void Awake()
		{
			locomotion = GetComponent<EnemyLocomotion>();
			enemyAnimator = GetComponentInChildren<Animator>();
		}

		private void FixedUpdate()
		{
			HandleAttackCountdown( Time.fixedDeltaTime );
		}

		protected void HandleAttackCountdown(float fixedDeltaTime)
		{
			// Don't bother doing anything if our target does not exist
			if(locomotion.CurrentTarget == null)
			{
				currentTimeUntilNextAttack = 0f;
				return;
			}

			// Also don't do anything if they're too far away
			else if( GetSqrMagnitudeDistanceBetween(locomotion.CurrentTarget.position) > attackRadius * attackRadius)
			{
				currentTimeUntilNextAttack = 0f;
				return;
			}

			// Our target exists and is in range, let's do the counter
			currentTimeUntilNextAttack += fixedDeltaTime;
			if(currentTimeUntilNextAttack >= attackRate)
			{
				ExecuteAttack();
				currentTimeUntilNextAttack = 0f;
			}
			Mathf.Clamp(currentTimeUntilNextAttack, 0f, attackRate);
		}

		private float GetSqrMagnitudeDistanceBetween(Vector3 targetPosition)
        {
            Vector3 heading = targetPosition - transform.position;
            return heading.sqrMagnitude;
        }

		/// <summary>
		/// How will this type of attack handle its attack?
		/// </summary>
		protected virtual void ExecuteAttack() { }

#if UNITY_EDITOR
		private void OnDrawGizmosSelected()
		{
			Gizmos.color = Color.red;
			Gizmos.DrawWireSphere(transform.position, attackRadius);
		}
#endif
	}
}
