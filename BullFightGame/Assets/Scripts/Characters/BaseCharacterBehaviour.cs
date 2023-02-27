using MrPigCore;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacterBehaviour : StateMachine
{
    public ManagerHelper managerHelper => baseManagerHelper as ManagerHelper;

   

    public override void Setup(BaseManagerHelper baseManagerHelper)
    {
        base.Setup(baseManagerHelper);
    }

  
}
