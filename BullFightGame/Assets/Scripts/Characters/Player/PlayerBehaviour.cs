using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : BaseCharacterBehaviour
{
    private Rigidbody rigidBody;

    [SerializeField] private float heavyAttackStrength;
    [SerializeField] private float heavyAttackCooldown;

    [SerializeField] private float lightAttackStrength;
    [SerializeField] private float lightAttackCooldown;

    [SerializeField] private float lookRotationSpeed;

    [SerializeField] private float dodgeSpeed;
    [SerializeField] private float dodgeCooldown;


    public float GetHeavyAttackCooldown() 
    { 
        return heavyAttackCooldown;
    }

    public float GetLightAttackCooldown()
    {
        return lightAttackCooldown;
    }

    public float GetDodgeCooldown()
    {
        return dodgeCooldown;
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
        transform.Rotate(0, Input.GetAxis("Mouse X") * lookRotationSpeed, 0);
    }

    public void HeavyAttack()
    {
        Vector3 force = transform.forward * heavyAttackStrength;
        rigidBody.AddForce(force, ForceMode.Impulse);
    }

    public void LightAttack()
    {
        Vector3 force = transform.forward * lightAttackStrength;
        rigidBody.AddForce(force, ForceMode.Impulse);
    }

    public void Dodge()
    {
        Vector3 force = transform.forward * dodgeSpeed;
        rigidBody.AddForce(force, ForceMode.Impulse);
    }
}
