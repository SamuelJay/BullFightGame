using MrPigEvents;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MrPigCore
{
    public abstract class State 
    {
        protected StateMachine behaviour;

        protected EventManager eventManager => behaviour.baseManagerHelper.eventManager;
        public State(StateMachine behaviourIn)
        {
            behaviour = behaviourIn;
            Enter();
        }

        public virtual void UpdateState() { }
        public virtual void Enter() { }
        public virtual void Exit(State nextState) {
            behaviour.SetState(nextState);
        }
        
    }
}