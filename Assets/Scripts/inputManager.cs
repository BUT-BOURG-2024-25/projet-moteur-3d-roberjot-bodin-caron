using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    private InputActionReference movementAction = null;

    public static InputManager instance { get { return _instance; } }
    private static InputManager _instance = null;

    public Vector3 movementInput { get; private set; }




    private void Awake()
    {
        if (_instance == null)
            _instance = this;
        else
            Destroy(gameObject);
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = movementAction.action.ReadValue<Vector2>();
        movementInput = new Vector3(moveInput.x, 0, moveInput.y);
        Debug.Log(moveInput.sqrMagnitude);
    }
}
