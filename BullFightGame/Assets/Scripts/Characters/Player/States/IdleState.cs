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
    }

    public override void HeavyAttack()
    {
        base.HeavyAttack();
        Debug.Log("IdleState HeavyAttack");
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
        if (playerBehaviour.movementInput.magnitude > threshold)
        {
            Exit(new MovingState(playerBehaviour));
        }
    }
    public override void Exit(State nextState)
    {
        
        base.Exit(nextState);
    }

}

