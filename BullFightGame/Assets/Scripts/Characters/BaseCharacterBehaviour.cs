using MrPigCore;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacterBehaviour : StateMachine
{
    public ManagerHelper managerHelper => baseManagerHelper as ManagerHelper;
    protected float health;
    [SerializeField] protected int startHealth;
    protected string id;
   
    public virtual void Setup(BaseManagerHelper baseManagerHelper, string id)
    {
        base.Setup(baseManagerHelper);
        this.id = id;
        health = startHealth;
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject go = collision.gameObject;
        PlayerBehaviour baseCharacter = gameObject.GetComponent<PlayerBehaviour>();
        
        if (baseCharacter != null) 
        {
            Debug.Log($"{id} Collided with other character");
            TriggerEvent<CollidedWithEnemyEvent>(new CollidedWithEnemyEvent(baseCharacter));
        }
    }
}
