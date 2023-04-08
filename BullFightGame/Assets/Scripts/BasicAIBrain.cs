using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAIBrain : BaseBehaviour
{

    private BasicOpponentData data;
    private PlayerBehaviour playerBehaviour;
    private PlayerBehaviour enemyPlayerBehaviour;
    private Vector3 enemyPosition;
    private Vector3 playerPosition;
    private Vector3 directionToPlayer;
    private float distanceToPlayer;

    public void Setup(BaseManagerHelper baseManagerHelper, PlayerBehaviour enemyPlayerBehaviour, BasicOpponentData data)
    {
        base.Setup(baseManagerHelper);
        playerBehaviour = GetComponent<PlayerBehaviour>();
        this.data = data;
        this.enemyPlayerBehaviour = enemyPlayerBehaviour;
    }

    private void Update()
    {
        enemyPosition = enemyPlayerBehaviour.transform.position;
        playerPosition = playerBehaviour.transform.position;
        directionToPlayer = enemyPosition - playerPosition;
        distanceToPlayer = directionToPlayer.magnitude;

        transform.LookAt(enemyPosition);
        if (distanceToPlayer > data.GetAttackThreshold())
        {
            playerBehaviour.SetMovementInput(directionToPlayer.normalized);
        }
        else
        {
            bool choice = (Random.value > 0.5f);
            playerBehaviour.SetMovementInput(new Vector3());
            if (choice)
            {
                playerBehaviour.HeavyAttackPressed();
            }
            else
            { 
                playerBehaviour.LightAttackPressed();
            }
        }
    }
}
