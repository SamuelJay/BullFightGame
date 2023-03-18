using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Manager
{
    [SerializeField] private GameObject playerPrefab;
    
    public PlayerBehaviour playerBehaviour { get; private set; }
    public PlayerBehaviour otherPlayerBehaviour { get; private set; }
    [SerializeField] private GameObject ringPrefab;
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
        canvasManager.Setup(managerHelper);
        managerHelper.SetCanvasManger(canvasManager);
        SetupLevel();
    }

    private void SetupLevel ()
    {
        ringObject = Instantiate(ringPrefab);
        GameObject player1Object = Instantiate(playerPrefab);
        playerBehaviour = player1Object.GetComponent<PlayerBehaviour>();
        playerBehaviour.Setup(managerHelper, "player");
        playerBehaviour.ActivateFollowCamera();
        InputHandler inputHandler= player1Object.AddComponent<InputHandler>();
        inputHandler.Setup(managerHelper);
        
        GameObject player2Object = Instantiate(playerPrefab);
        otherPlayerBehaviour = player2Object.GetComponent<PlayerBehaviour>();
        otherPlayerBehaviour.Setup(managerHelper, "notThePlayer");
    }
}
