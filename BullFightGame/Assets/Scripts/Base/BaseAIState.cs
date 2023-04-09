using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAIState : State
{
    protected BasicAIBrain basicAIBrain => behaviour as BasicAIBrain;
    protected PlayerBehaviour playerBehaviour => basicAIBrain.playerBehaviour;
    protected BasicOpponentData data => basicAIBrain.data;
    public BaseAIState(StateMachine behaviour) : base(behaviour)
    {
        
    }

    
}
