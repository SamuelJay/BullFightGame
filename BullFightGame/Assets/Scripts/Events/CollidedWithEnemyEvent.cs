using MrPigEvents;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollidedWithEnemyEvent : BaseEvent
{
    public PlayerBehaviour hitPlayer { get; private set; }
    
    public CollidedWithEnemyEvent(PlayerBehaviour hitPlayer)
    {
        this.hitPlayer = hitPlayer;
    }
}
