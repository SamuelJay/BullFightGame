using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIWaitState : BaseAIState {
    private float counter;
    private float waitTime;
    private State nextState;

    public AIWaitState(StateMachine behaviourIn, float waitTime, State nextState) : base(behaviourIn) {
        this.waitTime = waitTime;
        this.nextState = nextState;
    }

    public override void Enter() {
        base.Enter();
        Debug.Log("AIWaitState.Enter()");
    }

    public override void UpdateState() {
        base.UpdateState();
        basicAIBrain.LookAtEnemy();
        counter += Time.deltaTime;
        if (counter >= waitTime) {
            Exit(nextState);
        }
    }
}
