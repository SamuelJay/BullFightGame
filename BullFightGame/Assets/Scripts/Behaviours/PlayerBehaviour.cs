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
    private GameManager gameManager => managerHelper.gameManager;
    private Rigidbody rigidBody;
    private float lookInput;

    public override void Setup(BaseManagerHelper baseManagerHelper, string id)
    {
        base.Setup(baseManagerHelper,id);
        SetState(new PlayerIdleState(this));
        rigidBody = GetComponent<Rigidbody>();       
    }
    
    public void Dodge(int direction)
    {
        Vector3 force = transform.right * dodgeSpeed * direction;
        rigidBody.AddForce(force, ForceMode.Impulse);
    }

    public void SetLookInput(float lookInput)
    {
        this.lookInput = lookInput;
    }

    public void SetMovementInput(Vector3 movementInput)
    {
        this.movementInput = movementInput;

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

    public void ApplyDamage(float damage)
    {
        Debug.Log($"{id} I was Hit ! damage {damage} remaining health {health}");
        health -= damage;
        if (health <= 0) TriggerEvent<PlayerDiedEvent>(new PlayerDiedEvent(id));
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

    
    public void ActivateFollowCamera ()
    {
        followCamera.SetActive(true);
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

  
    private void Update()
    {
        float yDistanceToRing = gameManager.GetRingPosition().y-transform.position.y;
        if (yDistanceToRing > gameManager.GetYDistanceThreshold())
        {
            TriggerEvent<PlayerDiedEvent>(new PlayerDiedEvent(id));
        }
        state.UpdateState();
        transform.Rotate(0, lookInput * lookRotationSpeed, 0);
    }
    
}
