using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class MovePositionByAxis : MonoBehaviour
{

    [SerializeField]
    private float speed = 2f;

    [SerializeField]
    private float rotationSpeed = 10f;

    [SerializeField]
    private Rigidbody physicsBody;

    // Update is called once per frame
    void FixedUpdate()
    {

        Vector2 directionJoystickValue = UiManager.instance.PositionJoystick.Direction;

        Vector3 moveDirection = new(
            directionJoystickValue.x,
            0,
            directionJoystickValue.y);

        Vector3 globalVelocity = moveDirection * speed;

        // Appliquer la vélocité au Rigidbody
        physicsBody.velocity = new Vector3(globalVelocity.x, physicsBody.velocity.y, globalVelocity.z);
        Vector2 rotationJoystickValue = UiManager.instance.RotationJoystick.Direction;

        if (rotationJoystickValue.magnitude > 0 || directionJoystickValue.magnitude>0)
        {
            Vector2 playerDirection = directionJoystickValue;
            if(rotationJoystickValue.magnitude > 0)
            {
                playerDirection = UiManager.instance.RotationJoystick.Direction;
            }

            Vector3 LookDirection = new Vector3(playerDirection.x, 0, playerDirection.y);

            Quaternion toRotation = Quaternion.LookRotation(LookDirection.normalized);
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, Time.deltaTime * rotationSpeed);
        }
    }
}
