using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectPac.Components.Traps
{
  /// <summary>
  /// Base class for an obstacle that will damage the player in some way.
  /// The activation of how the trap damages the player is done through animations.
  /// </summary>
  public abstract class Trap : MonoBehaviour
  {
    protected Animator trapAnimator;

    private void Start()
    {
      trapAnimator = GetComponent<Animator>();
    }

    /// <summary>
    /// Have this trap do what it's supposed to.
    /// Meant to be called through an animator.
    /// </summary>
    public virtual void ExecuteTrap() { }
  }
}
