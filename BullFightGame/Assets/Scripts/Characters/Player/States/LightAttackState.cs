using MrPigCore;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightAttackState : BasePlayerState
{
    private float cooldown => playerBehaviour.GetLightAttackCooldown();
    private float counter;
    public LightAttackState(PlayerBehaviour behaviourIn) : base(behaviourIn) {
    }
    public override void Enter()
    {
        base.Enter();
        //Debug.Log("LIGHTATTACK");
        playerBehaviour.LightAttack();
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
