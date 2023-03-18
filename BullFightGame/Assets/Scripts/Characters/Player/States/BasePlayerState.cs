using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlayerState : BaseCharacterState
{
    protected PlayerBehaviour playerBehaviour => behaviour as PlayerBehaviour;
    
    protected float threshold = 0.01f;
    public BasePlayerState(PlayerBehaviour behaviourIn) : base(behaviourIn) { }

    public virtual void HeavyAttack() { }
    public virtual void LightAttack() { }
    public virtual void LeftDodge() { }
    public virtual void RightDodge() { }
}
