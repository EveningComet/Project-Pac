using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProjectPac.Components.Entities;

namespace ProjectPac.Components.Traps
{
	/// <summary>
	/// Trap that fires projectiles towards a direction.
	/// </summary>
	public class ProjectileTrap : Trap
	{
		/// <summary>
		/// The projectile this trap uses.
		/// </summary>
		[SerializeField] private Projectile trapProjectile;

		/// <summary>
		/// Stores the position, as well as the direction, that a <see cref="Projectile"/> should be spawned.
		/// </summary>
		[SerializeField] private Transform fireTransform;

		public override void ExecuteTrap()
		{
			// TODO: Probably want to object pool this for better performance.
			// Fire the projectile
			var p = Instantiate(trapProjectile, fireTransform.position, fireTransform.localRotation);
			p.gameObject.transform.SetParent(null);
		}
	}
}
