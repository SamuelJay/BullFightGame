using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Manager
{
    public PlayerBehaviour player1Behaviour { get; private set; }
    public PlayerBehaviour player2Behaviour { get; private set; }
    public RingController ringController { get; private set; }

    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject ringPrefab;
    [SerializeField] private int yDistanceThreshold;
    
    
    private SceneLoaderManager sceneLoaderManager=>managerHelper.sceneLoaderManager;
    
    public ManagerHelper managerHelper
    {
        get
        {
            return baseManagerHelper as ManagerHelper;
        }
    }

    private UIManager uiManager
    {
        get
        {
            return managerHelper.uiManager;
        }
    }

    public override void Setup(BaseManagerHelper baseManagerHelperIn)
    {
        base.Setup(baseManagerHelperIn);
       
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
        sceneLoaderManager.LoadMainMenuScene();
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
        player1Behaviour = player1Object.GetComponent<PlayerBehaviour>();
        player1Behaviour.Setup(managerHelper, "1");
        player1Behaviour.ActivateFollowCamera();
        InputHandler inputHandler = player1Object.AddComponent<InputHandler>();
        inputHandler.Setup(managerHelper);

        GameObject player2Object = Instantiate(playerPrefab, ringController.GetPlayerSpawnPoint(1).transform.transform.position, ringController.GetPlayerSpawnPoint(1).transform.transform.rotation);
        player2Behaviour = player2Object.GetComponent<PlayerBehaviour>();
        player2Behaviour.Setup(managerHelper, "2");
        BasicAIBrain basicAIBrain = player2Object.AddComponent<BasicAIBrain>();
        basicAIBrain.Setup(managerHelper, player1Behaviour);
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
