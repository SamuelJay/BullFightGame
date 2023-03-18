using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : Manager
{
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
        GameObject canvasObject= uiManager.CreateCanvas("MainMenuCanvas");
        CanvasManager canvasManager = canvasObject.GetComponent<CanvasManager>();
        canvasManager.Setup(managerHelper);
        managerHelper.SetCanvasManger(canvasManager);
    }
}
