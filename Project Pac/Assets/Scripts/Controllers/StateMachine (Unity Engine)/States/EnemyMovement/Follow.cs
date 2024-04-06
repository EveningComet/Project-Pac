using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectPac.StateMachineSystem
{
    /// <summary>
    /// State for when the AI is following the player.
    /// </summary>
    public class Follow : EnemyMovementState
    {
        private float slowDownRadius;
        private bool reachedEndOfPath = true;
        private float stoppingDistance;
        private Vector2 velocity = Vector2.zero;

        public Follow(EnemyLocomotion newOwner) : base(newOwner) {}

        public override void Enter()
        {
            // Path to our target
            SetPath(owner.CurrentTarget.position);

            currentNextSearchTime = 0f;
            stoppingDistance      = owner.StoppingDistance;
            slowDownRadius        = owner.ReturnToFollowDistance - stoppingDistance;
            if(slowDownRadius <= 0.1f)
            {
#if UNITY_EDITOR
                Debug.LogError("Follow :: Hey! Our slow down radius is either close to being zero or under zero!");
#endif
                slowDownRadius = owner.ReturnToFollowDistance;
            }
            reachedEndOfPath      = false;
        }

        public override void Exit()
        {
            base.Exit();
            currentNextSearchTime = 0f;
            reachedEndOfPath = true;
            velocity = Vector2.zero;
        }

        public override void FixedUpdate(float fDT)
        {
            base.FixedUpdate( fDT );

            currentNextSearchTime += fDT;
            if(currentNextSearchTime >= owner.NextSearchTime)
            {
                HandleSearchForTarget();
                currentNextSearchTime = 0f;
            }
        }

        protected override void ProcessMove(float fDT)
        {
            // Return to idle if our target is null
            if(owner.CurrentTarget == null)
            {
                owner.ChangeToState( 0 );
                return;
            }

            if(myPath == null || reachedEndOfPath == true)
                return;

            // We're done if there's nothing else to move towards
            if(currentWaypoint >= myPath.vectorPath.Count)
            {
                reachedEndOfPath = true;
                return;
            }

            // Otherwise, we still have stuff to do
            else
                reachedEndOfPath = false;

            // Follow the target
            Vector2 direction = ((Vector2)myPath.vectorPath[currentWaypoint] - rb2d.position).normalized;

            // Find what speed we should take
            float dist = GetSqrMagnitudeDistanceBetween(targetPathPos);
            float targetSpeed = (dist < slowDownRadius * slowDownRadius) ? moveSpeed * (dist / (slowDownRadius * slowDownRadius)) : moveSpeed;
            mover.SetVelocity(direction, targetSpeed);

            // Next waypoint
            dist = GetSqrMagnitudeDistanceBetween(myPath.vectorPath[currentWaypoint]);
            if (dist < owner.NextWaypointDistance * owner.NextWaypointDistance)
                currentWaypoint++;
        }

        protected override void UpdateAnimations(float dT)
        {
            // Update the animations, based on our target's position
            var animDirection = (Vector2)owner.CurrentTarget.position - (Vector2)owner.transform.position;
            enemyAnimator.SetFloat("MoveX", animDirection.x);
            enemyAnimator.SetFloat("MoveY", animDirection.y);
            enemyAnimator.SetFloat("MoveMagnitude", animDirection.magnitude);
        }

        protected override void HandleSearchForTarget()
        {
            // Fallback if we get too close
            if(stoppingDistance * stoppingDistance >= GetSqrMagnitudeDistanceBetween(targetPathPos))
            {
            	owner.ChangeToState( 2 );
                return;
            }

            SetPath(owner.CurrentTarget.position);
        }
    }
}
