using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace ProjectPac.GameControl.Audio
{
    /// <summary>
    /// Responsible for playing music in the game and managing some other audio things.
    /// </summary>
    public class AudioManager : MonoBehaviour
    {
        /// <summary>
        /// Ref/Copy of an empty game object. This is so we can "cleanly" create a copy of a passed audio source.
        /// </summary>
        [SerializeField] private GameObject emptyGOPrefab;

        private void OnEnable()
        {
            AudioCaller.SetAudioManager(this);
        }

        private void OnDisable()
        {
            AudioCaller.SetAudioManager(null);
        }

        /// <summary>
        /// Create a copy of the passed audio source at the passed position.
        /// </summary>
        public void PlayClipAtPoint(AudioSource source, Vector3 position)
        {
            // TODO: This should be object pooled for a big game, but since this is a small game, I don't think we should care too much about this.
            var go = Instantiate(emptyGOPrefab);
            go.transform.position = position;
            AudioSource aSource = go.AddComponent<AudioSource>();
            aSource.clip = source.clip;
            aSource.pitch = source.pitch;
            aSource.outputAudioMixerGroup = source.outputAudioMixerGroup;
            Destroy(go, source.clip.length);
            aSource.Play();
        }
    }
}
