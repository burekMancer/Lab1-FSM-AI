using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class playerInputController : MonoBehaviour
{
    CharacterController characterController;

    InputAction moveAction;
    InputAction lookAction;

    Camera playerCamera;

    float moveSpeed = 5f;
    float rotateSpeed = 31f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
