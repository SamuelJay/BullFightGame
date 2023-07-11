using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Manager
{
    public PlayerBehaviour player1Behaviour { get; private set; }
    public PlayerBehaviour player2Behaviour { get; private set; }
    public RingController ringController { get; private set; }


    [SerializeField] private Material[] playerMaterials;
    
    [SerializeField] private BasicOpponentData basicOpponentData;
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject ringPrefab;
    [SerializeField] private int yDistanceThreshold;
    
    private SceneLoaderManager sceneLoaderManager=>appManager.sceneLoaderManager;
    private InputHandler inputHandler;
    private BasicAIBrain basicAIBrain;

    private UIManager uiManager
    {
        get
        {
            return appManager.uiManager;
        }
    }

    public override void Setup(AppManager appManager)
    {
        base.Setup(appManager);
       
        StartListeningToEvent<PlayerDiedEvent>(OnPlayerDiedEvent);
        StartListeningToEvent<GameExitButtonEvent>(OnGameExitButtonEvent);
        
        SetupLevel();
    }

    private void OnGameExitButtonEvent(object sender, EventArgs e)
    {
        sceneLoaderManager.LoadMainMenuScene();
    }

    private void OnPlayerDiedEvent(object sender, EventArgs e)
    {
        PlayerDiedEvent playerDiedEvent = (PlayerDiedEvent)e;
        Debug.Log($"GameManager OnPlayerDiedEvent {playerDiedEvent.playerID}");
        uiManager.ShowGameOverPanel(playerDiedEvent.playerID);
        Destroy(inputHandler);
        Destroy(basicAIBrain);

        
    }

    public int GetYDistanceThreshold() 
    {
        return yDistanceThreshold;
    }

    public Vector3 GetRingPosition()
    {
        return ringController.transform.position;
    }

    private void SetupLevel()
    {
        GameObject ringObject = Instantiate(ringPrefab);
        ringController = ringObject.GetComponent<RingController>();

        GameObject player1Object = Instantiate(playerPrefab, ringController.GetPlayerSpawnPoint(0).transform.transform.position, ringController.GetPlayerSpawnPoint(0).transform.transform.rotation);
        player1Object.GetComponentInChildren<Renderer>().material = playerMaterials[0];
        player1Behaviour = player1Object.GetComponent<PlayerBehaviour>();
        player1Behaviour.Setup(appManager, "1");
        player1Behaviour.ActivateFollowCamera();
        inputHandler = player1Object.AddComponent<InputHandler>();
        inputHandler.Setup(appManager);

        GameObject player2Object = Instantiate(playerPrefab, ringController.GetPlayerSpawnPoint(1).transform.transform.position, ringController.GetPlayerSpawnPoint(1).transform.transform.rotation);
        player2Object.GetComponentInChildren<Renderer>().material = playerMaterials[1];
        player2Behaviour = player2Object.GetComponent<PlayerBehaviour>();
        player2Behaviour.Setup(appManager, "2");
        basicAIBrain = player2Object.AddComponent<BasicAIBrain>();
        basicAIBrain.Setup(appManager, player1Behaviour, basicOpponentData);
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            TriggerEvent<GameExitButtonEvent>(new GameExitButtonEvent());
        }
        
    }

    private void OnDestroy()
    {
        StopListeningToEvent <PlayerDiedEvent>(OnPlayerDiedEvent);
    }
}
