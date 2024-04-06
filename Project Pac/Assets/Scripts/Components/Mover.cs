using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectPac.Components.Entities
{
    /// <summary>
    /// Component meant to be attached to a thing that can move.
    /// It does not move by itself, it only gets told to move.
    /// </summary>
    public class Mover : MonoBehaviour
    {
        /// <summary>
        /// Stores the speed and direction this object will move to.
        /// </summary>
        private Vector2 velocity = Vector2.zero;
        private const float moveMagFlipThreshold = 0.1f;

        private SpriteRenderer sr;
        private Rigidbody2D rb2d;

        [SerializeField] private bool usesForceToMove = false;
        [SerializeField] private bool usesVelocityToMove = false;

        private void Start()
        {
            rb2d = GetComponent<Rigidbody2D>();
            sr   = GetComponentInChildren<SpriteRenderer>();
        }

        private void FixedUpdate()
        {
            DoMove(Time.fixedDeltaTime);
        }

        private void DoMove(float delta)
        {
            if(usesForceToMove == true)
                rb2d.AddForce(velocity * delta);
            else if(usesVelocityToMove == true)
                rb2d.velocity = velocity;

            if(rb2d.velocity.x >= moveMagFlipThreshold)
                sr.flipX = false;
            else if(rb2d.velocity.x <= -moveMagFlipThreshold)
                sr.flipX = true;
        }

        public void SetVelocity(Vector2 direction, float speed)
        {
            velocity = direction * speed;
        }
    }
}
