using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : BaseCharacterBehaviour
{
    
    public Vector3 movementInput { get; private set; }
    [SerializeField] private float heavyAttackStrength;
    [SerializeField] private float heavyAttackCooldown;
    [SerializeField] private float lightAttackStrength;
    [SerializeField] private float lightAttackCooldown;
    [SerializeField] private float lookRotationSpeed;
    [SerializeField] private float dodgeSpeed;
    [SerializeField] private float dodgeCooldown;
    private BasePlayerState playerState => state as BasePlayerState;
    private Rigidbody rigidBody;
    private float lookInput;

    public override void Setup(BaseManagerHelper baseManagerHelper)
    {
        base.Setup(baseManagerHelper);
        SetState(new IdleState(this));
        rigidBody = GetComponent<Rigidbody>();
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

    public void SetLookInput(float lookInput) 
    {
        this.lookInput = lookInput;
    }
    
    public void SetMovementInput(Vector3 movementInput) 
    {
        this.movementInput = movementInput;
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

    public void HeavyAttackPressed()
    {
        playerState.HeavyAttack();
    }

    public void LightAttackPressed()
    {
        playerState.LightAttack();
    }

    public void LeftDodgePressed()
    {
        playerState.LeftDodge();
    }
    
    public void RightDodgePressed()
    {
        playerState.RightDodge();
    }
    private void Update()
    {
        state.UpdateState();
        transform.Rotate(0, lookInput * lookRotationSpeed, 0);
    }
}
