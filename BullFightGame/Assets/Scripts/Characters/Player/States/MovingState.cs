using MrPigCore;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingState : BasePlayerState
{

    protected float speed = 0.025f;
    public MovingState(PlayerBehaviour behaviourIn) : base(behaviourIn)
    {
        Debug.Log("MovingState MovingState");
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("MovingState Enter");
        behaviour.StartListeningToEvent<HeavyAttackButtonPressedEvent>(OnHeavyAttackButtonPressedEvent);
        behaviour.StartListeningToEvent<LightAttackButtonPressedEvent>(OnLightAttackButtonPressedEvent);
        behaviour.StartListeningToEvent<RightDodgePressedEvent>(OnRightDodgePressedEvent);
        behaviour.StartListeningToEvent<LeftDodgePressedEvent>(OnLeftDodgePressedEvent);
    }

    private void OnHeavyAttackButtonPressedEvent(object sender, EventArgs e)
    {
        Exit(new HeavyAttackState(playerBehaviour));
    }

    private void OnLightAttackButtonPressedEvent(object sender, EventArgs e)
    {
        Debug.Log("IdleState OnLightAttackButtonPressedEvent");
        Exit(new LightAttackState(playerBehaviour));
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
    public override void UpdateState()
    {
        base.UpdateState();
        if (inputHandler.movementInput.magnitude < threshold)
        {
            Exit(new IdleState(playerBehaviour));
        }
        playerBehaviour.transform.position += inputHandler.movementInput * speed;
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

