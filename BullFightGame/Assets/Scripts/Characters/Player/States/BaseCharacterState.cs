using MrPigCore;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacterState : State
{
    BaseCharacterBehaviour characterBehaviour=>behaviour as BaseCharacterBehaviour;
    
    public BaseCharacterState(BaseCharacterBehaviour behaviourIn) : base(behaviourIn) { }
}
