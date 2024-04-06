using System.Collections;
using System.Collections.Generic;
using GeneralUnityEngineCode.StateMachineSystem;
using UnityEngine;
using Pathfinding;
using ProjectPac.Components.Entities;

namespace ProjectPac.StateMachineSystem
{
    /// <summary>
    /// Responsible for managing how an AI should move.
    /// </summary>
    /// <remarks>
    /// If desired for clean code, this state machine could be an abstract base class for different
    /// enemy types (ones that can follow the player and have a melee attack, etc.).
    /// </remarks>
    [RequireComponent(typeof(Mover))]
    public class EnemyLocomotion : StateMachine<EnemyMovementState>
    {
        public Rigidbody2D Rb2d { get; private set; }
        public Seeker Seeker { get; private set; } // A* Pathfinding Project
        public Animator EnemyAnimator { get; private set; }
        public Mover Mover { get; private set; }

        #region Enemy Movement Stats

        // Enemy Stats
        [Header("Enemy Movement Stats")]
        [SerializeField] private float moveSpeed = 3f;
        public float MoveSpeed { get { return moveSpeed; } }

        /// <summary>
        /// How many seconds should we wait for finding a new target?
        /// Mainly used by the idle state.
        /// </summary>
        [SerializeField] private float nextSearchTime = 0.5f;
        public float NextSearchTime { get { return nextSearchTime; } }

	    // TODO: Refactor this to be named retreating distance.
        /// <summary>
        /// How close we should get to our target before stopping.
        /// </summary>
        [SerializeField] private float stoppingDistance = 3f;
        public float StoppingDistance { get { return stoppingDistance; } }

        /// <summary>
        /// How far away this character may get from their target before returning to the follow state.
        /// </summary>
        [SerializeField] private float returnToFollowDistance = 10f;
        public float ReturnToFollowDistance { get { return returnToFollowDistance; } }

        /// <summary>
        /// How far away this character can "look".
        /// </summary>
        [SerializeField] private float awarenessRadius = 10f;
        public float AwarenessRadius { get { return awarenessRadius; } }


        /// <summary>
        /// How close this character has to be to a waypoint in order to move to the next waypoint.
        /// </summary>
        [SerializeField] private float nextWaypointDistance = 3f;
        public float NextWaypointDistance { get { return nextWaypointDistance; } }

        /// <summary>
        /// What is this AI interested in finding?
        /// </summary>
        [SerializeField] private LayerMask targetableMask;
        public LayerMask TargetableMask { get { return targetableMask; } }
        #endregion

        /// <summary>
        /// Keeps track of our target. Also, a quick and dirty way for other classes to call this.
        /// </summary>
        public Transform CurrentTarget { get; private set; }

        private void Start()
        {
            Rb2d = GetComponent<Rigidbody2D>();
            Seeker = GetComponent<Seeker>();
            EnemyAnimator = GetComponentInChildren<Animator>();
            Mover = GetComponent<Mover>();

            // Create the states based on the kind of AI this is
            AddNewState( 0, new Idle(this) );
            AddNewState( 1, new Follow(this) );
            AddNewState( 2, new Fallback(this) );
            ChangeToState( 0 );
        }

        private void Update()
        {
            currentState.Update(Time.deltaTime);
        }

        private void FixedUpdate()
        {
            currentState.FixedUpdate(Time.fixedDeltaTime);
        }

        public void SetTarget(Transform newTarget)
        {
            CurrentTarget = newTarget;
        }

        public void ClearTarget()
        {
            CurrentTarget = null;
        }

#if UNITY_EDITOR
            private void OnDrawGizmosSelected()
            {
                Gizmos.color = Color.yellow;
                Gizmos.DrawWireSphere(transform.position, awarenessRadius);

                Gizmos.color = Color.blue;
                Gizmos.DrawWireSphere(transform.position, returnToFollowDistance);

                Gizmos.color = Color.green;
                Gizmos.DrawWireSphere(transform.position, stoppingDistance);
            }
#endif
    }
}
