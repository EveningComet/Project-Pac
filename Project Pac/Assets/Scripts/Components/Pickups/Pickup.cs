using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectPac.Components.Collectibles
{
    /// <summary>
    /// An item that can be picked up by a player.
    /// </summary>
    public abstract class Pickup : MonoBehaviour
    {
        /// <summary>
        /// The sound to play when we pick up this item.
        /// </summary>
        [SerializeField] protected AudioSource pickupSound;
    }
}
