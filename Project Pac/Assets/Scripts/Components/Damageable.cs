using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectPac.Components.Entities
{
    /// <summary>
    /// A thing that can be destroyed in the game world.
    /// </summary>
    public class Damageable : MonoBehaviour
    {
    	#region Delegates / Events
    	/// <summary>
    	/// Delegate/Event that tells a listener what to do when our health changes. Mainly used to
    	/// tell the healthbar/counter how much health to display.
    	/// </summary>
    	public delegate void OnHealthChange(int amount, bool isHealing);
    	public event OnHealthChange OnHealthChanged;

    	/// <summary>
    	/// Delegate/Event that tells a listener what to do when this damageable is dead.
    	/// Mainly used for telling the game that the player is dead.
    	/// </summary>
    	public delegate void OnDeath(Damageable damageable);
    	public event OnDeath OnIAmDead;

    	#endregion

        [Header("Health Stats")]
        [SerializeField] private int maxHP = 3;     // How much damage that can be taken before dying
        public int MaxHP { get { return maxHP; } }  // Accessor for this character's max hp
        public int CurrentHP { get; private set; }

        [Header("Particle Effects")]
        [SerializeField] private GameObject hitEffect = null;
        [SerializeField] private GameObject deathEffect = null;

        [Header("Sound Effects")]
        [SerializeField] private AudioSource painSound;
        [SerializeField] private AudioSource deathSound;
        [SerializeField] private float minPitch = 0.5f;
        [SerializeField] private float maxPitch = 3f;

        private bool isInvulnerable = false;

        private void Awake()
        {
            CurrentHP = maxHP;
        }

        /// <summary>
        /// Toggle this character's invulnerability.
        /// </summary>
        public void SetInvulnerability()
        {
            isInvulnerable = !isInvulnerable;
        }

        /// <summary>
        /// Explicitly set whether or not this character is invulnerable.
        /// </summary>
        public void SetInvulnerability(bool newValue)
        {
            isInvulnerable = newValue;
        }

        public void TakeDamage(int damageAmount = 0)
        {
            if(isInvulnerable == true)
            	return;

            CurrentHP -= damageAmount;

            // Tell anyone listening that we have taken damage
            if(OnHealthChanged != null)
            	OnHealthChanged( damageAmount, false );

            // Play our hit effect, if we have one
            if(hitEffect != null)
                Instantiate(hitEffect, transform.position, Quaternion.identity);

            // Play our pain sound, if we have one
            if(painSound != null && CurrentHP > 0)
            {
                this.painSound.pitch = UnityEngine.Random.Range(minPitch, maxPitch);
                painSound.Play();
            }

            // Check if we should die
            if(CurrentHP <= 0)
                Die();
        }

        public void HealDamage(int healAmount = 0)
        {
            // Heal us, but don't overheal
            CurrentHP += healAmount;
            if(CurrentHP > maxHP)
                CurrentHP = maxHP;

            // Tell anyone that cares we have been healed
            if(OnHealthChanged != null)
                OnHealthChanged( healAmount, true );
        }

        private void Die()
        {
            // Tell anyone listening we're dead
            if(OnIAmDead != null)
            	OnIAmDead( this );

            // Play our death particle if we have one
            if(deathEffect != null)
            {
                var dE = Instantiate(deathEffect, transform.position, Quaternion.identity);
                Destroy(dE, 5f);
            }

            // Play any death sound effect, if we have one
            if(deathSound != null)
            {
                // TODO: Play the sound!
                this.deathSound.pitch = UnityEngine.Random.Range(minPitch, maxPitch);
                ProjectPac.GameControl.Audio.AudioCaller.PlayClipAtPoint(deathSound, transform.position);
            }

            Destroy(gameObject);
        }
    }
}
