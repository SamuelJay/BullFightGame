using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIFollowState : BaseAIState
{
    public AIFollowState(StateMachine behaviourIn) : base(behaviourIn)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("AIFollowState.Enter()");
    }

    public override void UpdateState()
    {
        base.UpdateState();
        if (basicAIBrain.distanceToEnemy > data.GetAttackThreshold())
        {
            playerBehaviour.SetMovementInput(basicAIBrain.directionToEnemy.normalized);
        }
        else 
        {
            playerBehaviour.SetMovementInput(Vector3.zero);
            Exit(new AIAttackState(basicAIBrain));
        }
        
    }
}
