using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class State
{
    protected StateMachine behaviour;

    protected EventManager eventManager => behaviour.appManager.eventManager;
    public State(StateMachine behaviourIn)
    {
        behaviour = behaviourIn;

    }

    public virtual void UpdateState() { }
    public virtual void Enter() { }
    public virtual void Exit(State nextState)
    {
        behaviour.SetState(nextState);
    }

}
