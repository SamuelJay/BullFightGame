using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAttackState : BaseAIState
{
    public AIAttackState(StateMachine behaviourIn) : base(behaviourIn)
    {
    }

    public override void Enter()
    {
        base.Enter();
        bool choice = (Random.value > 0.5f);
        playerBehaviour.SetMovementInput(new Vector3());
        if (choice)
        {
            playerBehaviour.HeavyAttackPressed();
        }
        else
        {
            playerBehaviour.LightAttackPressed();
        }
        Exit(new AIWaitState(basicAIBrain));
    }

    public override void UpdateState()
    {
        base.UpdateState();
        
    }
}
