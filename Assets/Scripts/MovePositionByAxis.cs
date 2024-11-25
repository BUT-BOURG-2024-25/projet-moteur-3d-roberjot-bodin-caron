using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovePositionByAxis : MonoBehaviour
{

    [SerializeField]
    private float speed = 2f;

    [SerializeField]
    private float jumpPower = 20;

    [SerializeField]
    private Rigidbody physicsBody;

    [SerializeField]
    private bool moveWithJoystick = false;

    // Start is called before the first frame update
    void Start()
    {
        InputManager.instance.registerOnJumpInput(jump);
    }


    private void OnDestroy()
    {
        InputManager.instance.unregisterOnJumpInput(jump);
    }


    private void jump(InputAction.CallbackContext callbackContext)
    {
        physicsBody.AddForce(Vector3.up * jumpPower);
    }



    // Update is called once per frame
    void Update()
    {
        Vector3 movement = InputManager.instance.movementInput;


        if (moveWithJoystick)
        {
            movement = new Vector3(
                UiManager.instance.joystick.Direction.x,
                0.0f,
                UiManager.instance.joystick.Direction.y);
        }

        UnityEngine.Debug.Log(this.transform.rotation.y *180);
        Vector3 moveDirection = Quaternion.AngleAxis(this.transform.rotation.y * 180, Vector3.up) * movement;

        Vector3 newVelocity = moveDirection* speed;
        newVelocity.y = physicsBody.velocity.y;
        physicsBody.velocity = newVelocity;
        
        
    }
}
