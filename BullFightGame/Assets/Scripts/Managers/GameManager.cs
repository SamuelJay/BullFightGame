using MrPigCore;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Manager
{
    [SerializeField] private GameObject playerPrefab;
    private GameObject playerObject;
    public PlayerBehaviour playerBehaviour { get; private set; }
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
        playerObject = Instantiate(playerPrefab);
        playerBehaviour = playerObject.GetComponent<PlayerBehaviour>();
        playerBehaviour.Setup(managerHelper);
    }
}
