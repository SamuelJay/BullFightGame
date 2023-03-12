using MrPigCore;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : BasePlayerState
{
    public IdleState(PlayerBehaviour behaviourIn) : base(behaviourIn)
    {
        Debug.Log("IdleState IdleState");
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("IdleState Enter");
        behaviour.StartListeningToEvent<HeavyAttackButtonPressedEvent>(OnHeavyAttackButtonPressedEvent);
        behaviour.StartListeningToEvent<LightAttackButtonPressedEvent>(OnLightAttackButtonPressedEvent);
        behaviour.StartListeningToEvent<RightDodgePressedEvent>(OnRightDodgePressedEvent);
        behaviour.StartListeningToEvent<LeftDodgePressedEvent>(OnLeftDodgePressedEvent);
    }

    private void OnLeftDodgePressedEvent(object sender, EventArgs e)
    {
        Debug.Log("IdleState OnLeftDodgePressedEvent");
        Exit(new DodgeState(playerBehaviour, -1));
    }

    private void OnRightDodgePressedEvent(object sender, EventArgs e)
    {
        Debug.Log("IdleState OnRightDodgePressedEvent");
        Exit(new DodgeState(playerBehaviour, 1));
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
        behaviour.StopListeningToEvent<HeavyAttackButtonPressedEvent>(OnHeavyAttackButtonPressedEvent);
        behaviour.StopListeningToEvent<LightAttackButtonPressedEvent>(OnLightAttackButtonPressedEvent);
        behaviour.StopListeningToEvent<RightDodgePressedEvent>(OnRightDodgePressedEvent);
        behaviour.StopListeningToEvent<LeftDodgePressedEvent>(OnLeftDodgePressedEvent);
        base.Exit(nextState);
    }

}

