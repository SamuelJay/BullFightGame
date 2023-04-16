using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class PlayerDodgeState : BasePlayerState
{
    private float cooldown => playerBehaviour.GetDodgeCooldown();
    private float counter;
    private int direction;
    public PlayerDodgeState(PlayerBehaviour behaviourIn, int direction) : base(behaviourIn)
    {
        //Debug.Log("DodgeState DodgeState");
        this.direction = direction;
    }

    public override void Enter()
    {
        base.Enter();
        //Debug.Log($"player {playerBehaviour.GetID()} DodgeState Enter()");
        playerBehaviour.Dodge(direction);
    }
    public override void UpdateState()
    {
        base.UpdateState();
        counter += Time.deltaTime;
        if (counter >= cooldown)
        {
            Exit(new PlayerIdleState(playerBehaviour));
        }
    }
    public override void Exit(State nextState)
    {
        base.Exit(nextState);
    }
}
