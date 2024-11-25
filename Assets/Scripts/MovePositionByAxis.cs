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
    private Rigidbody physicsBody;

    [SerializeField]
    private bool moveWithJoystick = false;

    // Start is called before the first frame update
    void Start()
    {
    }


    private void OnDestroy()
    {
    }



    // Update is called once per frame
    void Update()
    {
        Vector3 movement = InputManager.instance.movementInput;


        if (moveWithJoystick)
        {
            movement = new Vector3(
                UiManager.instance.PositionJoystick.Direction.x,
                0.0f,
                UiManager.instance.PositionJoystick.Direction.y);
        }

        Vector3 moveDirection = Quaternion.AngleAxis(this.transform.rotation.y * 180, Vector3.up) * movement;

        Vector3 newVelocity = moveDirection* speed;
        newVelocity.y = physicsBody.velocity.y;
        physicsBody.velocity = newVelocity;


        Vector2 directionJoystickValue = UiManager.instance.RotationJoystick.Direction;
        Vector3 LookDirection = new Vector3(directionJoystickValue.x, 0, directionJoystickValue.y);

        
        
        
    }
}
