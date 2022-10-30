using MrPigCore;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacterBehaviour : StateMachine
{
    public ManagerHelper managerHelper => baseManagerHelper as ManagerHelper;
    public InputManager inputManager => managerHelper.inputManager;
    // Start is called before the first frame update


    public override void Setup(BaseManagerHelper baseManagerHelperIn)
    {
        base.Setup(baseManagerHelperIn);
        Debug.Log("Manager Helper "+(managerHelper==null)+ " Input Manager " + (inputManager == null));
        //inputController = gameObject.AddComponent<InputManager>();
        //inputController.Setup(baseManagerHelper);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
