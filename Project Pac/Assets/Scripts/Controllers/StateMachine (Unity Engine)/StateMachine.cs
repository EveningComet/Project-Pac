using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GeneralUnityEngineCode.StateMachineSystem
{
    /// <summary>
    /// Base class for something controlled by a <see cref="State"/>.
    /// </summary.
    /// <typeparam name="T">The type of <see cref="State"/> this machine cares about.</typeparam>
    public abstract class StateMachine<T> : MonoBehaviour where T: State
    {
        protected Dictionary<int, T> myStates = new Dictionary<int, T>();
        protected T currentState = null;
        private bool isTransitioning = false;

        public void AddNewState(int newStateKey, State newState)
        {
            if(myStates.ContainsKey(newStateKey) == true)
                return;

            myStates.Add(newStateKey, newState as T);
        }

        public void ChangeToState(int stateToChangeTo)
        {
            if(myStates.ContainsKey(stateToChangeTo) == false || isTransitioning == true)
                return;

            isTransitioning = true;

            if(currentState != null)
                currentState.Exit();

            currentState = myStates[stateToChangeTo] as T;

            currentState.Enter();
            isTransitioning = false;
        }
    }
}
