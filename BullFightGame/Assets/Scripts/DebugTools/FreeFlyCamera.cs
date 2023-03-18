using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeFlyCamera : MonoBehaviour {


    
    //private Camera camera;
    private GameObject playerObject;
    private Vector2 rotation;

    private bool shift;
    private bool ctrl;
    [SerializeField] private float speed;
    private float lookSpeed;

    private void Start() {
        
        lookSpeed = 3.7f;
        rotation = new Vector2(0, 0);
    }

    private void Update() {
        if (Input.GetKey(KeyCode.Mouse1)) {

            rotation.y += Input.GetAxis("Mouse X");
            rotation.x += -Input.GetAxis("Mouse Y");
            transform.eulerAngles = rotation * lookSpeed;
            float useSpeed;
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) {
                useSpeed = speed * 2;
            } else {
                useSpeed = speed;
            }
            if (Input.GetKey(KeyCode.W)) {
                transform.position += transform.forward * useSpeed;
            }
            if (Input.GetKey(KeyCode.A)) {
                transform.position -= transform.right * useSpeed;
            }
            if (Input.GetKey(KeyCode.S)) {
                transform.position -= transform.forward * useSpeed;
            }
            if (Input.GetKey(KeyCode.D)) {
                transform.position += transform.right * useSpeed;
            }
            if (Input.GetKey(KeyCode.Q)) {
                transform.position += transform.up * useSpeed;
            }
            if (Input.GetKey(KeyCode.E)) {
                transform.position -= transform.up * useSpeed;
            }
            if (Input.GetKeyDown(KeyCode.M)) {
                playerObject.transform.position = transform.position; //Moves the player to the flycam's position. Make sure not to just move the player's camera.
            }

        }

    }
}