using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectPac.Components.Entities
{
	/// <summary>
	/// Component for an enemy that attacks with projectiles.
	/// </summary>
	public class ProjectileAttacker : EnemyAttack
	{
		[Header("Projectile Info")]
		[SerializeField] private Projectile projectilePrefab;
		[SerializeField] private Transform firePivotPoint;

		protected override void ExecuteAttack()
		{
			// Get the direction
			Vector3 targetDir = (locomotion.CurrentTarget.position - transform.position).normalized;
			float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg - 90f;
			firePivotPoint.rotation = Quaternion.Euler(
				new Vector3(0f, 0f, angle)
			);

			// Let the animator take it from here
			enemyAnimator.SetTrigger("FireProjectile");
		}

		public void FireProjectile()
		{
			// TODO: Object pool this probably.
			// Fire the projectile
			var pToFire = Instantiate(projectilePrefab, firePivotPoint.position, firePivotPoint.rotation);
			pToFire.transform.SetParent(null);
			enemyAnimator.ResetTrigger("FireProjectile");
		}
	}
}
