using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIIdleState : BaseAIState
{
    

    public AIIdleState(StateMachine behaviour) : base(behaviour)
    {
    }



    public override void Enter()
    {
        base.Enter();
        Debug.Log("AIIdleState.Enter()");
    }
}
