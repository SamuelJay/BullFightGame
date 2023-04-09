using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : BasePlayerState
{
    
    public PlayerIdleState(PlayerBehaviour behaviourIn) : base(behaviourIn)
    {
        //Debug.Log("IdleState IdleState");
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log($"player {playerBehaviour.GetID()} IdleState");
    }

    public override void HeavyAttack()
    {
        base.HeavyAttack();
        Debug.Log("IdleState HeavyAttack");
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
        if (playerBehaviour.movementInput.magnitude > threshold)
        {
            Exit(new PlayerMovingState(playerBehaviour));
        }
    }
    public override void Exit(State nextState)
    {
        
        base.Exit(nextState);
    }

}

