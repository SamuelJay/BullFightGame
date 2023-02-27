using MrPigCore;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MrPigBaseBehaviour
{
    public InputActions inputActions;
    public Vector2 movementInput { get; private set; }
    public override void Setup(BaseManagerHelper baseManagerHelperIn)
    {
        inputActions = new InputActions();
        inputActions.PlayerInput.Enable();
    }
    void FixedUpdate()
    {
        movementInput = inputActions.PlayerInput.Movement.ReadValue<Vector2>();
    }
}
