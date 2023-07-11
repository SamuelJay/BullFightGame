using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacterBehaviour : StateMachine
{
    protected float health;
    [SerializeField] protected int startHealth;
    public string id { get; private set; }
   
    public virtual void Setup(AppManager appManager, string id)
    {
        base.Setup(appManager);
        this.id = id;
        health = startHealth;
    }

    public string GetID() 
    {
        return id;
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject go = collision.gameObject;
        PlayerBehaviour baseCharacter = gameObject.GetComponent<PlayerBehaviour>();
        
        if (baseCharacter != null) 
        {
            //Debug.Log($"{id} Collided with other character");
            TriggerEvent<CollidedWithEnemyEvent>(new CollidedWithEnemyEvent(baseCharacter));
        }
    }
}
