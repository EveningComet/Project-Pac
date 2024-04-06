namespace GeneralUnityEngineCode.StateMachineSystem
{
    /// <summary>
    /// Base class for an object inside a state machine.
    /// </summary>
    public abstract class State
    {
        /// <summary>
        /// What to do when entering.
        /// </summary>
        public virtual void Enter() { }

        /// <summary>
        /// What to do when exiting.
        /// </summary>
        public virtual void Exit() { }
    }
}
