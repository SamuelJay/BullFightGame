using MrPigCore;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : BasePlayerState
{
    public IdleState(PlayerBehaviour behaviourIn) : base(behaviourIn)
    {
       
    }
    public override void Enter()
    {
        base.Enter();
        Debug.Log("IDLE Enter");
        behaviour.StartListeningToEvent<HeavyAttackButtonPressedEvent>(OnHeavyAttackButtonPressedEvent);
    }
    private void OnHeavyAttackButtonPressedEvent(object sender, EventArgs e)
    {
        Debug.Log("IdleState OnHeavyAttackButtonPressedEvent");
        Exit(new HeavyAttackState(playerBehaviour));
    }

    public override void UpdateState()
    {
        base.UpdateState();
        if (inputManager.inputAxis.magnitude > threshold)
        {
            Exit(new MovingState(playerBehaviour));
        }
    }
    public override void Exit(State nextState)
    {
        base.Exit(nextState);
        behaviour.StopListeningToEvent<HeavyAttackButtonPressedEvent>(OnHeavyAttackButtonPressedEvent);
    }
}

