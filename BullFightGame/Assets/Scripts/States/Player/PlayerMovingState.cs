using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovingState : BasePlayerState
{

    protected float speed = 0.025f;
    public PlayerMovingState(PlayerBehaviour behaviourIn) : base(behaviourIn)
    {
        //Debug.Log($"player {playerBehaviour.GetID()} MovingState.Enter()");
    }

    public override void Enter()
    {
        base.Enter();
        //Debug.Log("MovingState Enter");
    }

    public override void HeavyAttack()
    {
        base.HeavyAttack();
        Exit(new PlayerHeavyAttackState(playerBehaviour));
    }

    public override void LightAttack()
    {
        base.LightAttack();
        Debug.Log("IdleState OnLightAttackButtonPressedEvent");
        Exit(new PlayerLightAttackState(playerBehaviour));
    }

    public override void RightDodge()
    {
        base.RightDodge();
        Debug.Log("IdleState OnRightDodgePressedEvent");
        Exit(new PlayerDodgeState(playerBehaviour, 1));
    }

    public override void LeftDodge()
    {
        base.LeftDodge();
        Debug.Log("IdleState OnLeftDodgePressedEvent");
        Exit(new PlayerDodgeState(playerBehaviour, -1));
    }
    
    public override void UpdateState()
    {
        base.UpdateState();
        if (playerBehaviour.movementInput.magnitude < threshold)
        {
            Exit(new PlayerIdleState(playerBehaviour));
        }
        playerBehaviour.transform.position += playerBehaviour.movementInput * speed;
    }

    public override void Exit(State nextState)
    {
        
        base.Exit(nextState);
    }
}

