using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GeneralUnityEngineCode.StateMachineSystem;
using Pathfinding;
using ProjectPac.Components.Entities;

namespace ProjectPac.StateMachineSystem
{
    /// <summary>
    /// Base class for something that controls an enemy's movement.
    /// </summary>
    public abstract class EnemyMovementState : State
    {
        /// <summary>
        /// How long until we can search for our target again.
        /// </summary>
        protected float currentNextSearchTime;
        protected EnemyLocomotion owner;
        protected Rigidbody2D rb2d;
        protected float moveSpeed;
        protected Animator enemyAnimator;
        protected Mover mover;

        // A* Pathfinding Project Bookkeeping
        protected Seeker seeker;
        protected Path myPath;
        protected int currentWaypoint = 0;
        protected Vector3 targetPathPos;

        public EnemyMovementState(EnemyLocomotion newOwner)
        {
            owner = newOwner;
            rb2d  = newOwner.Rb2d;
            seeker = newOwner.Seeker;
            moveSpeed = newOwner.MoveSpeed;
            enemyAnimator = newOwner.EnemyAnimator;
            mover = newOwner.Mover;
        }

        public override void Exit()
        {
            // Reset the current waypoint
            currentWaypoint = 0;
        }

        public virtual void Update(float dT)
        {
            UpdateAnimations( dT );
        }

        public virtual void FixedUpdate(float fDT)
        {
            ProcessMove( fDT );
        }

        /// <summary>
        /// What should this movement state do?
        /// </summary>
        protected virtual void ProcessMove(float fDT) {}

        /// <summary>
        /// Contains code for an enemy's animations.
        /// </summary>
        protected virtual void UpdateAnimations(float dT) {}

        /// <summary>
        /// How should this state search for its target?
        /// </summary>
        protected virtual void HandleSearchForTarget() {}

        /// <summary>
        /// What should we do, when we have finished our path?
        /// </summary>
        protected void OnPathComplete(Path p)
        {
            if(p.error == true)
                return;

            // Set our new path
            currentWaypoint = 0;
            myPath = p;
        }

        /// <summary>
        /// Set a path to follow.
        /// </summary>
        protected void SetPath(Vector2 newPath)
        {
            SetPath( new Vector3(newPath.x, newPath.y, 0f) );
        }

        /// <summary>
        /// Set a path to follow.
        /// </summary>
        protected void SetPath(Vector3 newPath)
        {
            // Only look for a new path when we have finished our current one
            if(seeker.IsDone() == true)
            {
                targetPathPos = newPath;
                seeker.StartPath(rb2d.position, targetPathPos, OnPathComplete);
            }
        }

        // TODO: Probably want to put this in some sort of extentions class.
        protected float GetSqrMagnitudeDistanceBetween(Vector3 position)
        {
            return GetSqrMagnitudeDistanceBetween((Vector2)position);
        }

        protected float GetSqrMagnitudeDistanceBetween(Vector2 position)
        {
            Vector2 heading = (position - rb2d.position);
            return heading.sqrMagnitude;
        }

        // TODO: Implement this.
        /// <summary>
        /// Used to smooth the enemies movement speed.
        /// </summary>
        protected float GetSmoothTime(float smoothTime)
        {
            return 0f;
        }
    }
}
