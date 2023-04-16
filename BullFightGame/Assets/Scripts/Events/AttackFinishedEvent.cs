using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackFinishedEvent : BaseEvent
{
    public PlayerBehaviour playerBehaviour { get; private set; }
    public AttackFinishedEvent(PlayerBehaviour playerBehaviour) 
    {
        this.playerBehaviour = playerBehaviour; 
    }
}
