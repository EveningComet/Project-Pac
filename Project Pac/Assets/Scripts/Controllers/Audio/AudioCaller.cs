using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectPac.GameControl.Audio
{
    /// <summary>
    /// Used to call our game's audio manager.
    /// </summary>
    public static class AudioCaller
    {
        private static AudioManager audioManager = null;

        /// <summary>
        /// Set the audio manager we are going to call.
        /// </summary>
        public static void SetAudioManager(AudioManager am)
        {
            audioManager = am;
        }

        /// <summary>
        /// Tell the audio manager to create a copy of the passed audio source, at the specified position.
        /// </summary>
        public static void PlayClipAtPoint(AudioSource source, Vector3 position)
        {
            audioManager.PlayClipAtPoint(source, position);
        }
    }
}
