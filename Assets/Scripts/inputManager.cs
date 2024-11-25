using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    private InputActionReference movementAction = null;
    [SerializeField]
    private InputActionReference jumpAction = null;

    [SerializeField]
    private InputActionReference mouseClickAction = null;
    // Start is called before the first frame update

    public static InputManager instance { get { return _instance; } }
    private static InputManager _instance = null;

    public Vector3 movementInput { get; private set; }






    public void registerOnJumpInput(Action<InputAction.CallbackContext> onJumpAction)
    {
        jumpAction.action.performed += onJumpAction;
    }

    public void unregisterOnJumpInput(Action<InputAction.CallbackContext> onJumpAction)
    {
        jumpAction.action.performed -= onJumpAction;
    }



    public void registerOnClickInput(Action<InputAction.CallbackContext> onClickAction)
    {
        mouseClickAction.action.performed += onClickAction;
    }

    public void unregisterOnClickInput(Action<InputAction.CallbackContext> onClickAction)
    {
        mouseClickAction.action.performed -= onClickAction;
    }




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
    }
}
