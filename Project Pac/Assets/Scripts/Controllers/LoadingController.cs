using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ProjectPac.GameControl
{
    /// <summary>
    /// Manages the various times the game must load.
    /// </summary>
    public class LoadingController : MonoBehaviour
    {
        /// <summary>
        /// Are we still loading in a scene?
        /// </summary>
        public bool IsLoading { get; private set; }

        /// <summary>
        /// Load the scene of the passed string, if it exists.
        /// </summary>
        public void LoadScene(string sceneName)
        {
            if(SceneManager.GetSceneByName(sceneName) == null)
            {
#if UNITY_EDITOR
                Debug.LogErrorFormat("LoadingController :: The passed scene, ({0}), does not exist!", sceneName);
#endif
                return;
            }

            else if(IsLoading == true)
            {
#if UNITY_EDITOR
                Debug.LogWarning("LoadingController :: Asked to load a scene while we were already loading one in. We're not going to load in another scene.");
#endif
                return;
            }

            StartCoroutine( LoadPassedScene( sceneName ) );
        }

        /// <summary>
        /// Get the name of the active scene. Mainly used for testing and restarting levels/scenes.
        /// </summary>
        public string GetActiveSceneName()
        {
            return SceneManager.GetActiveScene().name;
        }

        private IEnumerator LoadPassedScene(string sceneName)
        {
            IsLoading = true;

            // Wait for all the stuff to load in
            yield return new WaitForSeconds(1f); // TODO: We should really make sure all the stuff finished loading, instead of just putting in some random time.

            // Load the scene now that everything's in
            SceneManager.LoadScene( sceneName );

            IsLoading = false;
        }
    }
}
