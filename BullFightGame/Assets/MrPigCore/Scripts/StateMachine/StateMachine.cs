
namespace MrPigCore
{
    public abstract class StateMachine : MrPigBaseBehaviour
    {
        protected State state;

        public virtual void SetState(State newState) {
            state = newState;
            state.Enter();
        }
    }
}
