using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAIBrain : StateMachine {
    public BasicOpponentData data { get; private set; }
    public PlayerBehaviour playerBehaviour { get; private set; }
    public PlayerBehaviour enemyPlayerBehaviour { get; private set; }
    public Vector3 enemyPosition { get; private set; }
    public Vector3 playerPosition { get; private set; }
    public Vector3 directionToEnemy { get; private set; }
    public float distanceToEnemy { get; private set; }

    public void Setup(BaseManagerHelper baseManagerHelper, PlayerBehaviour enemyPlayerBehaviour, BasicOpponentData data) {
        base.Setup(baseManagerHelper);
        playerBehaviour = GetComponent<PlayerBehaviour>();
        this.data = data;
        this.enemyPlayerBehaviour = enemyPlayerBehaviour;
        SetState(new AIFollowState(this));
    }

    public void LookAtEnemy() {
        float rotationSpeed = data.GetRotationSpeed();
        Quaternion targetRotation = Quaternion.LookRotation(directionToEnemy);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    private void Update() {
        enemyPosition = enemyPlayerBehaviour.transform.position;
        playerPosition = transform.position;
        directionToEnemy = enemyPosition - playerPosition;
        distanceToEnemy = Vector3.Distance(enemyPosition, playerPosition);
        state.UpdateState();
    }
}
