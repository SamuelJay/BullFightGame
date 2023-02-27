using MrPigCore;
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
        inputActions = new InputActions();
        inputActions.PlayerInput.Enable();
    }
    void FixedUpdate()
    {
        lookInput = inputActions.PlayerInput.Look.ReadValue<float>();
        Vector2 movementInputVector2 = inputActions.PlayerInput.Movement.ReadValue<Vector2>();

        movementInput = transform.right * movementInputVector2.x + transform.forward * movementInputVector2.y;
    }
}
