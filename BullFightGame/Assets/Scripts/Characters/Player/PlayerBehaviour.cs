using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : BaseCharacterBehaviour
{
    [SerializeField] private float heavyAttackStrength;
    private Rigidbody rigidBody;
    [SerializeField] private float heavyAttackCooldown;

    public float GetHeavyAttackCooldown() 
    { 
        return heavyAttackCooldown;
    }

    public override void Setup(BaseManagerHelper baseManagerHelperIn)
    {
        base.Setup(baseManagerHelperIn);
        SetState(new IdleState(this));

        rigidBody= GetComponent<Rigidbody>();
    }
    private void Update()
    {
        state.UpdateState();
    }

    public void HeavyAttack()
    {
        Vector3 force = transform.forward * heavyAttackStrength;
        rigidBody.AddForce(force, ForceMode.Impulse);
    }
}
