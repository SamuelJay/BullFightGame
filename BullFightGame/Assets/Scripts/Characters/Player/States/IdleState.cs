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
        behaviour.StartListeningToEvent<LightAttackButtonPressedEvent>(OnLightAttackButtonPressedEvent);
    }

    private void OnLightAttackButtonPressedEvent(object sender, EventArgs e)
    {
        Debug.Log("IdleState OnLightAttackButtonPressedEvent");
        Exit(new LightAttackState(playerBehaviour));
    }

    private void OnHeavyAttackButtonPressedEvent(object sender, EventArgs e)
    {
        Debug.Log("IdleState OnHeavyAttackButtonPressedEvent");
        Exit(new HeavyAttackState(playerBehaviour));
    }

    public override void UpdateState()
    {
        base.UpdateState();
        if (inputHandler.movementInput.magnitude > threshold)
        {
            Exit(new MovingState(playerBehaviour));
        }
    }
    public override void Exit(State nextState)
    {
        base.Exit(nextState);
        behaviour.StopListeningToEvent<HeavyAttackButtonPressedEvent>(OnHeavyAttackButtonPressedEvent);
        behaviour.StopListeningToEvent<LightAttackButtonPressedEvent>(OnLightAttackButtonPressedEvent);
    }

}

