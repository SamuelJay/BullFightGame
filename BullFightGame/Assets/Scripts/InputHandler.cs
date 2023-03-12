using MrPigCore;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MrPigBaseBehaviour
{
    public InputActions inputActions;
    public Vector3 movementInput { get; private set; }
    public float lookInput { get; private set; }

    public override void Setup(BaseManagerHelper baseManagerHelperIn)
    {
        base.Setup(baseManagerHelperIn);
        inputActions = new InputActions();
        inputActions.PlayerInput.Enable();
        inputActions.PlayerInput.HeavyAttack.performed += OnHeavyAttackPerformed;
        inputActions.PlayerInput.LightAttack.performed += OnLightAttackPerformed;
        inputActions.PlayerInput.RightDodge.performed += OnRightDogdePerformed;
        inputActions.PlayerInput.LeftDodge.performed += OnLeftDogdePerformed;
    }

    private void OnLightAttackPerformed(InputAction.CallbackContext obj)
    {
        TriggerEvent<LightAttackButtonPressedEvent>(new LightAttackButtonPressedEvent());
    }

    private void OnHeavyAttackPerformed(InputAction.CallbackContext obj)
    {
        TriggerEvent<HeavyAttackButtonPressedEvent>(new HeavyAttackButtonPressedEvent());
    }

    private void OnLeftDogdePerformed(InputAction.CallbackContext obj)
    {
        TriggerEvent<LeftDodgePressedEvent>(new LeftDodgePressedEvent());
    } 
    
    private void OnRightDogdePerformed(InputAction.CallbackContext obj)
    {
        TriggerEvent<RightDodgePressedEvent>(new RightDodgePressedEvent());
    }

    void FixedUpdate()
    {
        lookInput = inputActions.PlayerInput.Look.ReadValue<float>();
        Vector2 movementInputVector2 = inputActions.PlayerInput.Movement.ReadValue<Vector2>();

        movementInput = transform.right * movementInputVector2.x + transform.forward * movementInputVector2.y;
    }
}
