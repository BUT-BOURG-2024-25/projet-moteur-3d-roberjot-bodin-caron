using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : Singleton<InputManager>
{
    [SerializeField]
    private InputActionReference movementAction = null;

    public Vector3 movementInput { get; private set; }

  

    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = movementAction.action.ReadValue<Vector2>();
        movementInput = new Vector3(moveInput.x, 0, moveInput.y);
    }
}
