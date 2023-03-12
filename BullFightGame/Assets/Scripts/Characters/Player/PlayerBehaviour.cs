using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : BaseCharacterBehaviour
{
    public InputHandler inputHandler { get; private set; }
    [SerializeField] private float heavyAttackStrength;
    [SerializeField] private float heavyAttackCooldown;
    [SerializeField] private float lightAttackStrength;
    [SerializeField] private float lightAttackCooldown;
    [SerializeField] private float lookRotationSpeed;
    [SerializeField] private float dodgeSpeed;
    [SerializeField] private float dodgeCooldown;

    private Rigidbody rigidBody;

    public override void Setup(BaseManagerHelper baseManagerHelper)
    {
        base.Setup(baseManagerHelper);
        SetState(new IdleState(this));

        inputHandler = gameObject.AddComponent<InputHandler>();
        rigidBody = GetComponent<Rigidbody>();

        inputHandler.Setup(managerHelper);
    }

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
    private void Update()
    {
        state.UpdateState();
        transform.Rotate(0, inputHandler.lookInput * lookRotationSpeed, 0);
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

    public void Dodge(int direction)
    {
        Vector3 force = transform.right * dodgeSpeed *direction;
        rigidBody.AddForce(force, ForceMode.Impulse);
    }
}
