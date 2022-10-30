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
    }
    public override void Enter()
    {
        base.Enter();
        Debug.Log("MOVING");
        behaviour.StartListeningToEvent<HeavyAttackButtonPressedEvent>(OnHeavyAttackButtonPressedEvent);
    }
    private void OnHeavyAttackButtonPressedEvent(object sender, EventArgs e)
    {
        Exit(new HeavyAttackState(playerBehaviour));
    }

    public override void UpdateState()
    {
        base.UpdateState();
        if (inputManager.inputAxis.magnitude < threshold)
        {
            Exit(new IdleState(playerBehaviour));
        }
        playerBehaviour.transform.position += inputManager.inputAxis * speed;
    }
    public override void Exit(State nextState)
    {
        base.Exit(nextState);
        behaviour.StopListeningToEvent<HeavyAttackButtonPressedEvent>(OnHeavyAttackButtonPressedEvent);
    }
}

