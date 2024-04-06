using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectPac.StateMachineSystem
{
    /// <summary>
    /// State for when the AI has nothing else better to do.
    /// </summary>
    public class Idle : EnemyMovementState
    {
        public Idle(EnemyLocomotion newOwner) : base(newOwner) {}

        public override void Enter()
        {
            currentNextSearchTime = owner.NextSearchTime;
        }

        public override void Exit()
        {
            base.Exit();
            currentNextSearchTime = 0f;
        }

        public override void FixedUpdate(float fDT)
        {
            base.FixedUpdate( fDT );

            currentNextSearchTime += fDT;

            // Search for something to chase
            if(currentNextSearchTime >= owner.NextSearchTime)
            {
                HandleSearchForTarget();
                currentNextSearchTime = 0f;
            }
        }
        
        protected override void ProcessMove(float fDT)
        {
            // TODO: Pick a random spot to move to.
        }

        /// <summary>
        /// Search for a valid target that we can move to.
        /// </summary>
        protected override void HandleSearchForTarget()
        {
            // Look for a target
            GameObject nearestTarget = null;
            Collider2D[] potentialTargets = Physics2D.OverlapCircleAll(
                owner.transform.position,
                owner.AwarenessRadius,
                owner.TargetableMask
            );
            int numTargets = potentialTargets.Length;
            for(int i = 0; i < numTargets; i++)
            {
                // NOTE: If something more advanced is desired, have something to check for the nearest enemy
                nearestTarget = potentialTargets[i].gameObject;
            }

            // We have found a target, let's change to our follow state!
            if(nearestTarget != null)
            {
                owner.SetTarget(nearestTarget.transform);
                owner.ChangeToState( 1 );
            }
        }
    }
}
