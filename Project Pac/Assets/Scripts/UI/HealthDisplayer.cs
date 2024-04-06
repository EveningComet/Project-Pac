using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ProjectPac.Components.Entities;

namespace ProjectPac.UserInterface
{
	/// <summary>
	/// Displays a player's health.
	/// </summary>
	/// <remarks>
	/// This class should not care about the player or the thing it's monitoring dying- beyond turning itself off.
	/// </remarks>
	public class HealthDisplayer : MonoBehaviour
	{
		// Sprites we want to use to represent damage
		[SerializeField] private GameObject fullHeart;
		private Sprite fullHeartSprite;
		[SerializeField] private GameObject emptyHeart;
		private Sprite emptyHeartSprite;

		// These variables are used to make sure we set the correct amount of sprites
		private int currentHealth = 0;
		private int maxHealth     = 0;

		/// <summary>
		/// The character whose health we're monitoring.
		/// </summary>
		[SerializeField] private Damageable monitoredDamageable = null;

		void Start()
		{
			fullHeartSprite  = fullHeart.GetComponent<Image>().sprite;
			emptyHeartSprite = emptyHeart.GetComponent<Image>().sprite;

			// TODO: Testing code. Please delete for the "final" project. Some sort of manager should deal with this.
			if(monitoredDamageable != null)
				SetUpHealthForPlayer( monitoredDamageable );
		}

		private void OnDisable()
		{
			// Unsubscribe from the monitored damageable, if we have one
			if(monitoredDamageable != null)
				monitoredDamageable.OnHealthChanged -= OnHealthChanged;
		}

		public void SetUpHealthForPlayer(Damageable thingToMonitor)
		{
			// Subscribe to the damage event
			monitoredDamageable = thingToMonitor;
			monitoredDamageable.OnHealthChanged += OnHealthChanged;

			// Set the amount of needed hearts
			maxHealth     = monitoredDamageable.MaxHP;
			currentHealth = maxHealth;
			for(int i = 0; i < maxHealth; i++)
			{
				var hGO = Instantiate(fullHeart);
				hGO.transform.SetParent(this.transform);
			}
		}

		private void OnHealthChanged(int amount, bool isHealing)
		{
			if(isHealing == false)
			{
				currentHealth -= amount;

				int numHearts = transform.childCount;
				for(int i = 0; i < numHearts; i++)
				{
					if(i >= currentHealth)
					{
						// Get the sprite and change it
						ChangeHeart( i, false );
					}
				}
			}

			else
			{
				currentHealth += amount;
				if(currentHealth + amount > maxHealth)
					currentHealth = maxHealth;

				for (int i = currentHealth - amount; i < currentHealth; i++)
				{
					ChangeHeart( i, true );
				}
			}
		}

		/// <summary>
		/// Based on the passed index, and whether or not to heal, change the corresponding heart.
		/// </summary>
		private void ChangeHeart(int heartChildIndex, bool isHealing)
		{
			var heartToChange = transform.GetChild(heartChildIndex).gameObject;
			if(isHealing == true)
				heartToChange.GetComponent<Image>().sprite = fullHeartSprite;
			else
				heartToChange.GetComponent<Image>().sprite = emptyHeartSprite;
		}
	}
}
