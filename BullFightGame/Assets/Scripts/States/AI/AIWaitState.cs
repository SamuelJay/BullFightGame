using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIWaitState : BaseAIState
{
    private float counter;

    public AIWaitState(StateMachine behaviourIn) : base(behaviourIn)
    {
    }
    public override void UpdateState()
    {
        base.UpdateState();
        counter += Time.deltaTime;
        if (counter >= playerBehaviour.GetHeavyAttackCooldown())
        {
            Exit(new AIFollowState(basicAIBrain));
        }
    }

}
