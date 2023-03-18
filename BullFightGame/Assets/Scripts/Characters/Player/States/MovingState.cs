using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingState : BasePlayerState
{

    protected float speed = 0.025f;
    public MovingState(PlayerBehaviour behaviourIn) : base(behaviourIn)
    {
        //Debug.Log("MovingState MovingState");
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("MovingState Enter");
    }

    public override void HeavyAttack()
    {
        base.HeavyAttack();
        Exit(new HeavyAttackState(playerBehaviour));
    }

    public override void LightAttack()
    {
        base.LightAttack();
        Debug.Log("IdleState OnLightAttackButtonPressedEvent");
        Exit(new LightAttackState(playerBehaviour));
    }

    public override void RightDodge()
    {
        base.RightDodge();
        Debug.Log("IdleState OnRightDodgePressedEvent");
        Exit(new DodgeState(playerBehaviour, 1));
    }

    public override void LeftDodge()
    {
        base.LeftDodge();
        Debug.Log("IdleState OnLeftDodgePressedEvent");
        Exit(new DodgeState(playerBehaviour, -1));
    }
    
    public override void UpdateState()
    {
        base.UpdateState();
        if (playerBehaviour.movementInput.magnitude < threshold)
        {
            Exit(new IdleState(playerBehaviour));
        }
        playerBehaviour.transform.position += playerBehaviour.movementInput * speed;
    }

    public override void Exit(State nextState)
    {
        
        base.Exit(nextState);
    }
}

