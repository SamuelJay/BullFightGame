using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : BaseCharacterBehaviour
{
  
    public Vector3 movementInput { get; private set; }

    [SerializeField] private GameObject followCamera;
    [SerializeField] private float heavyAttackForce;
    [SerializeField] private float heavyAttackDamage;
    [SerializeField] private float heavyAttackCooldown;
    [SerializeField] private float lightAttackForce;
    [SerializeField] private float lightAttackDamage;
    [SerializeField] private float lightAttackCooldown;
    [SerializeField] private float lookRotationSpeed;
    [SerializeField] private float dodgeSpeed;
    [SerializeField] private float dodgeCooldown;
    private BasePlayerState playerState => state as BasePlayerState;
    private Rigidbody rigidBody;
    private float lookInput;

    public override void Setup(BaseManagerHelper baseManagerHelper, string id)
    {
        base.Setup(baseManagerHelper,id);
        SetState(new IdleState(this));
        rigidBody = GetComponent<Rigidbody>();       
    }

    public void ApplyDamage(float damage)
    {
        health -= damage;
        Debug.Log($"{id} I was Hit ! damage {damage} remaining health {health}");
    }

    public float GetHeavyAttackCooldown() 
    { 
        return heavyAttackCooldown;
    }
    
    public float GetHeavyAttackDamage() 
    { 
        return heavyAttackDamage;
    }

    public float GetLightAttackCooldown()
    {
        return lightAttackCooldown;
    }
    
    public float GetLightAttackDamage()
    {
        return lightAttackDamage;
    }

    public float GetDodgeCooldown()
    {
        return dodgeCooldown;
    }

    public void SetLookInput(float lookInput) 
    {
        this.lookInput = lookInput;
    }
    
    public void ActivateFollowCamera ()
    {
        followCamera.SetActive(true);
    }
    public void SetMovementInput(Vector3 movementInput) 
    {
        this.movementInput = movementInput;
        
    }

    public void HeavyAttack()
    {
        Vector3 force = transform.forward * heavyAttackForce;
        rigidBody.AddForce(force, ForceMode.Impulse);
    }

    public void LightAttack()
    {
        Vector3 force = transform.forward * lightAttackForce;
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
