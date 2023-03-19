using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAIBrain : BaseBehaviour
{
    [SerializeField] private int followThreshold;

    private PlayerBehaviour playerBehaviour;
    private PlayerBehaviour enemyPlayerBehaviour;
    private Vector3 enemyPosition;
    private Vector3 playerPosition;
    private Vector3 directionToPlayer;
    private float distanceToPlayer;

    public void Setup(BaseManagerHelper baseManagerHelper, PlayerBehaviour enemyPlayerBehaviour)
    {
        base.Setup(baseManagerHelper);
        playerBehaviour =GetComponent<PlayerBehaviour>();
        this.enemyPlayerBehaviour = enemyPlayerBehaviour;
    }

    private void Update()
    {
        enemyPosition = enemyPlayerBehaviour.transform.position;
        playerPosition = playerBehaviour.transform.position;
        directionToPlayer = enemyPosition-playerPosition;
        distanceToPlayer = directionToPlayer.magnitude;

        transform.LookAt(enemyPosition);
        //Debug.Log($"BasicAIBrain distanceToPlayer {distanceToPlayer}");
    }
}
