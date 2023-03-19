using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Manager
{
    public PlayerBehaviour player1Behaviour { get; private set; }
    public PlayerBehaviour player2Behaviour { get; private set; }
    
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject ringPrefab;
    [SerializeField] private int yDistanceThreshold;
    
    private SceneLoaderManager sceneLoaderManager=>managerHelper.sceneLoaderManager;
    private GameObject ringObject;
    
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
        GameObject canvasObject = uiManager.CreateCanvas("GameCanvas");
        CanvasManager canvasManager = canvasObject.GetComponent<CanvasManager>();
        StartListeningToEvent<PlayerDiedEvent>(OnPlayerDiedEvent);
        canvasManager.Setup(managerHelper);
        managerHelper.SetCanvasManger(canvasManager);
        SetupLevel();
    }

    private void OnPlayerDiedEvent(object sender, EventArgs e)
    {
        PlayerDiedEvent playerDiedEvent = (PlayerDiedEvent)e;
        Debug.Log($"GameManager OnPlayerDiedEvent {playerDiedEvent}");
        sceneLoaderManager.LoadMainMenuScene();
    }

    public int GetYDistanceThreshold() 
    {
        return yDistanceThreshold;
    }

    public Vector3 GetRingPosition()
    {
        return ringObject.transform.position;
    }

    private void SetupLevel ()
    {
        ringObject = Instantiate(ringPrefab);
        GameObject player1Object = Instantiate(playerPrefab);
        player1Behaviour = player1Object.GetComponent<PlayerBehaviour>();
        player1Behaviour.Setup(managerHelper, "player");
        player1Behaviour.ActivateFollowCamera();
        InputHandler inputHandler= player1Object.AddComponent<InputHandler>();
        inputHandler.Setup(managerHelper);
        
        GameObject player2Object = Instantiate(playerPrefab);
        player2Behaviour = player2Object.GetComponent<PlayerBehaviour>();
        player2Behaviour.Setup(managerHelper, "notThePlayer");
        BasicAIBrain basicAIBrain = player2Object.AddComponent<BasicAIBrain>();
        basicAIBrain.Setup(managerHelper, player1Behaviour);
    }
}
