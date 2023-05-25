using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAIState : State {
    protected BasicAIBrain basicAIBrain => behaviour as BasicAIBrain;
    protected PlayerBehaviour playerBehaviour => basicAIBrain.playerBehaviour;
    protected BasicOpponentData data => basicAIBrain.data;

    public BaseAIState(StateMachine behaviour) : base(behaviour) {

    }

    public override void Enter() {
        base.Enter();
        playerBehaviour.StartListeningToEvent<PlayerDiedEvent>(OnPlayerDiedEvent);

    }

    private void OnPlayerDiedEvent(object sender, EventArgs e) {
        Exit(new InactiveState(playerBehaviour));
    }
}
