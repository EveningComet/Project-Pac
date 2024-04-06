using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectPac.StateMachineSystem
{
	/// <summary>
	/// State for when an enemy gets too close to a target and should move back.
	/// </summary>
	public class Fallback : EnemyMovementState
	{
	    private float returnToFollowDistance;
	    public Fallback(EnemyLocomotion newOwner) : base(newOwner) {}

	    public override void Enter()
	    {
#if UNITY_EDITOR
	     	Debug.LogFormat("Fallback :: Enemy({0}) has gotten too close to their target and are now falling back.", owner.gameObject.name);
#endif
			returnToFollowDistance = owner.ReturnToFollowDistance;
	    }

	    protected override void ProcessMove(float fDT)
	    {
			// The target we're after is dead, return to idle
			if(owner.CurrentTarget == null)
			{
				owner.ChangeToState( 0 );
				return;
			}

	       	// TODO: We should probably use the A* Pathfinding Project.
	     	// Go in the opposite direction
	     	Vector2 direction = (rb2d.position - (Vector2)owner.CurrentTarget.position).normalized;
	     	mover.SetVelocity(direction, moveSpeed);

	     	// We have gotten too far from our player, what should we do?
			float dist = GetSqrMagnitudeDistanceBetween(owner.CurrentTarget.position);
	     	if(dist > returnToFollowDistance * returnToFollowDistance)
	     	{
	     	    owner.ChangeToState( 1 );
	     	    return;
	     	}
	    }
	}
}
