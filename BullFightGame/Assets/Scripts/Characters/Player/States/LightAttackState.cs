using MrPigCore;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightAttackState : BasePlayerState
{
    public LightAttackState(PlayerBehaviour behaviourIn) : base(behaviourIn) {
    }
    public override void Enter()
    {
        base.Enter();
        Debug.Log("LIGHTATTACK");
    }
    public override void UpdateState()
    {
        base.UpdateState();
    }
    public override void Exit(State nextState)
    {
        base.Exit(nextState);
    }
}
