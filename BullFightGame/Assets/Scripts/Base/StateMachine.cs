
public abstract class StateMachine : BaseBehaviour
{
    protected State state;

    public virtual void SetState(State newState)
    {
        state = newState;
        state.Enter();
    }
}
