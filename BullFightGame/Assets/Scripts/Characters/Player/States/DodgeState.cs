using MrPigCore;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class DodgeState : BasePlayerState
{
    private float cooldown => playerBehaviour.GetDodgeCooldown();
    private float counter;
    public DodgeState(PlayerBehaviour behaviourIn) : base(behaviourIn)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("Dodge");
        playerBehaviour.Dodge();
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
