using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : Manager
{
   /* public ManagerHelper managerHelper
    {
        get
        {
            return baseManagerHelper as ManagerHelper;
        }
    }*/

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
        
    }
}
