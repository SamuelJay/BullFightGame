using MrPigCore;

using UnityEngine;

public class InputManager : Manager
{

    public Vector3 inputAxis { get; private set; }
    [SerializeField] private bool relativeMovement;

    private ManagerHelper managerHelper => baseManagerHelper as ManagerHelper; 
    private GameManager gameManager => managerHelper.gameManager; 

    private Transform playerTransform => gameManager.playerBehaviour.transform;
    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        if (relativeMovement)
        {
            inputAxis = playerTransform.right * x + playerTransform.forward * z;
        }
        else
        { 
            inputAxis = new Vector3(x, 0, z);
        }
        
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            Debug.Log("InputController mouse0 Pressed");
            TriggerEvent<HeavyAttackButtonPressedEvent>(new HeavyAttackButtonPressedEvent());
        }
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            Debug.Log("InputController mouse1 Pressed");
            TriggerEvent<LightAttackButtonPressedEvent>(new LightAttackButtonPressedEvent());
        }
    }

}
