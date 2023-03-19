using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDiedEvent : BaseEvent
{
    public string playerID { get; private set; }

    public PlayerDiedEvent(string playerID)
    {
        this.playerID = playerID;
    }
}
