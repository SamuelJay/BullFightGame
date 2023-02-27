using MrPigCore;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyAttackState : BasePlayerState
{
    private float cooldown => playerBehaviour.GetHeavyAttackCooldown();
    private float counter;
    public HeavyAttackState(PlayerBehaviour behaviourIn) : base(behaviourIn)
    {
    }
    public override void Enter()
    {
        base.Enter();
        //Debug.Log("HeavyAttackState");
        playerBehaviour.HeavyAttack();
    }
    public override void UpdateState()
    {
        base.UpdateState();
        counter += Time.deltaTime;
        if (counter >= cooldown)
        {
            Exit(new IdleState(playerBehaviour));
        }
    }
    public override void Exit(State nextState)
    {
        base.Exit(nextState);
    }
}
