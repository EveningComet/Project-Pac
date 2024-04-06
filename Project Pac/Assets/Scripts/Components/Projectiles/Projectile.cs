using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectPac.Components.Entities
{
	/// <summary>
	/// A thing that can be fired and hit something.
	/// </summary>
	public abstract class Projectile : MonoBehaviour
	{
	    [SerializeField] protected float fireSpeed = 10f;
	    [SerializeField] protected int damage = 1;

	    protected Rigidbody2D rb;

	    void OnEnable()
	    {
	    	rb = GetComponent<Rigidbody2D>();
	    	rb.velocity = transform.up * fireSpeed;
	    	Destroy(gameObject, 10f);
	    }
	}
}
