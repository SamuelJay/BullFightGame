using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : BaseBehaviour
{
    public InputActions inputActions;
    public Vector3 movementInput { get; private set; }
    public float lookInput { get; private set; }
    private PlayerBehaviour playerBehaviour;

    private StateMachine stateMachine;
    public override void Setup(BaseManagerHelper baseManagerHelperIn)
    {
        base.Setup(baseManagerHelperIn);
        inputActions = new InputActions();
        inputActions.PlayerInput.Enable();
        inputActions.PlayerInput.HeavyAttack.performed += OnHeavyAttackPerformed;
        inputActions.PlayerInput.LightAttack.performed += OnLightAttackPerformed;
        inputActions.PlayerInput.RightDodge.performed += OnRightDodgePerformed;
        inputActions.PlayerInput.LeftDodge.performed += OnLeftDodgePerformed;
        playerBehaviour = GetComponent<PlayerBehaviour>();
    }

    private void OnLightAttackPerformed(InputAction.CallbackContext obj)
    {
        playerBehaviour.LightAttackPressed();
    }

    private void OnHeavyAttackPerformed(InputAction.CallbackContext obj)
    {
        playerBehaviour.HeavyAttackPressed();
    }

    private void OnLeftDodgePerformed(InputAction.CallbackContext obj)
    {
        playerBehaviour.LeftDodgePressed();
    } 
    
    private void OnRightDodgePerformed(InputAction.CallbackContext obj)
    {
        playerBehaviour.RightDodgePressed();
    }

    void FixedUpdate()
    {
        lookInput = inputActions.PlayerInput.Look.ReadValue<float>();
        playerBehaviour.SetLookInput(lookInput);
        Vector2 movementInputVector2 = inputActions.PlayerInput.Movement.ReadValue<Vector2>();

        movementInput = transform.right * movementInputVector2.x + transform.forward * movementInputVector2.y;
        playerBehaviour.SetMovementInput(movementInput);
    }
}
