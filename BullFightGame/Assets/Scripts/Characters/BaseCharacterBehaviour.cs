using MrPigCore;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacterBehaviour : StateMachine
{
    public ManagerHelper managerHelper => baseManagerHelper as ManagerHelper;
    protected int health;
    protected int startHealth;
    protected string id;
   
    public virtual void Setup(BaseManagerHelper baseManagerHelper, string id)
    {
        base.Setup(baseManagerHelper);
        this.id = id;
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject go = collision.gameObject;
        BaseCharacterBehaviour baseCharacter = gameObject.GetComponent<BaseCharacterBehaviour>();
        
        if (baseCharacter != null) 
        {
            Debug.Log($"{id} Collided with other character");    
        }
    }
}
