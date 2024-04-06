using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectPac.Components.Entities
{
	/// <summary>
	/// Reusable component for managing a character's melee attack.
	/// Simply edit the collider of the thing this is attached to.
	/// </summary>
	public class MeleeDamageCollider : MonoBehaviour
	{
		#region Delegates / Events
			/// <summary>
			/// Used to tell whoever cares that this class hit something.
			/// This generic variant is mainly used to subtract hits from the player's weapon.
			/// </summary>
			public delegate void Hit();
			public event Hit OnHit;
		#endregion
		private Collider2D collider2D;    // Reference to our attached collider
		private int damageAmount = 0;
		private Damageable ownDamageable; // Used to prevent hurting self

		private void Awake()
		{
			collider2D = GetComponent<Collider2D>();
			ownDamageable = GetComponentInParent<Damageable>();
			collider2D.isTrigger = true;
			collider2D.enabled = false;
		}

		/// <summary>
		/// Initialize/Set how much damage this collider should do to things it hits.
		/// </summary>
		public void SetupDamage(int newAmount)
		{
			damageAmount = newAmount;
		}

		public void EnableDamageCollider()
		{
			collider2D.enabled = true;
		}

		/// <summary>
		/// Overload that allows us to spawn an effect when enabling the collider. Mainly used by the player to show off something cool.
		/// </summary>
		public void EnableDamageCollider(GameObject effect, float timeToKill, Transform t)
		{
			collider2D.enabled = true;
			GameObject spawnedEffect = Instantiate(effect, transform.position, t.rotation);
			Destroy(spawnedEffect, timeToKill);
		}

		public void DisableDamageCollider()
		{
			collider2D.enabled = false;
		}

		private void OnTriggerEnter2D(Collider2D col)
		{
			// TODO: Maybe make a list to prevent damaging the same person multiple times.
			var target = col.GetComponent<Damageable>();
			if(target != null && target != ownDamageable)
			{
				target.TakeDamage( damageAmount );

				// Tell whoever cares this object has hit something
				if(OnHit != null)
					OnHit();
			}
		}
	}
}
