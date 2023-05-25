using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBackupState : BaseAIState
{
    private Vector3 startingPostion;
    public AIBackupState(StateMachine behaviourIn) : base(behaviourIn)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("AIBackupState.Enter()");
        startingPostion = playerBehaviour.transform.position;

    }

    public override void UpdateState()
    {
        base.UpdateState();
        Debug.Log($"AIBackupState DistanceToEnemy {basicAIBrain.distanceToEnemy} BackupAmount {data.GetBackupAmount()} {basicAIBrain.distanceToEnemy < data.GetBackupAmount()}");
        if (Vector3.Distance(startingPostion, playerBehaviour.transform.position) < data.GetBackupAmount())
        {
            playerBehaviour.SetMovementInput(basicAIBrain.directionToEnemy.normalized * -1);
        }
        else
        {
            playerBehaviour.SetMovementInput(Vector3.zero);
            Exit(new AIFollowState(basicAIBrain));
        }

    }
}
