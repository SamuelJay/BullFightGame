using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLightAttackState : BasePlayerState
{
    private float cooldown => playerBehaviour.GetLightAttackCooldown();
    private float counter;
    public PlayerLightAttackState(PlayerBehaviour behaviourIn) : base(behaviourIn) {
    }
    public override void Enter()
    {
        base.Enter();
        //Debug.Log($"player {playerBehaviour.GetID()} LightAttackState.Enter()");
        playerBehaviour.LightAttack();
        playerBehaviour.StartListeningToEvent<CollidedWithEnemyEvent>(OnCollidedWithEnemyEvent);
    }
    private void OnCollidedWithEnemyEvent(object sender, EventArgs e)
    {
        CollidedWithEnemyEvent collidedWithEnemyEvent = (CollidedWithEnemyEvent)e;

        if (collidedWithEnemyEvent.hitPlayer != playerBehaviour)
        {
            collidedWithEnemyEvent.hitPlayer.ApplyDamage(playerBehaviour.GetLightAttackDamage());
        }
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
        playerBehaviour.TriggerEvent<AttackFinishedEvent>(new AttackFinishedEvent(playerBehaviour));
        playerBehaviour.StopListeningToEvent<CollidedWithEnemyEvent>(OnCollidedWithEnemyEvent);
        base.Exit(nextState);
    }
}
