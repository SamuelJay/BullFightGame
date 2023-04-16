using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AIAttackState : BaseAIState
{
    public AIAttackState(StateMachine behaviourIn) : base(behaviourIn)
    {
    }

    

    public override void Enter()
    {
        base.Enter();
        Debug.Log("AIAttackState.Enter()");
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
        basicAIBrain.StartListeningToEvent<AttackFinishedEvent>(OnAttackFinishedEvent);
    
        }

    private void OnAttackFinishedEvent(object sender, EventArgs e)
    {
        AttackFinishedEvent attackFinishedEvent = (AttackFinishedEvent)e;
        if (attackFinishedEvent.playerBehaviour == playerBehaviour)
        {
            Exit(new AIBackupState(basicAIBrain));
        }
    }

    public override void UpdateState()
    {
        base.UpdateState();
        
    }
}
