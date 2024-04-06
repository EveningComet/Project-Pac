using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Component meant to be attached to something that should not be destroyed during scene changes.
/// Mainly for <see cref="GameController"/>.
/// </summary>
public class DontDestroy : MonoBehaviour
{
    private void Awake()
    {
        // Don't allow multiple instances of this to exist
        var objs = GameObject.FindGameObjectsWithTag(this.gameObject.name);
        if(objs.Length > 1)
            Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);
    }
}
