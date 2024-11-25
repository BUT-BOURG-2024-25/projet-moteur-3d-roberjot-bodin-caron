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
     

        Vector3 moveDirection = new Vector3(
            UiManager.instance.PositionJoystick.Direction.x,
            0,
            UiManager.instance.PositionJoystick.Direction.y);

        Vector3 globalVelocity = moveDirection * speed;

        // Appliquer la vélocité au Rigidbody
        physicsBody.velocity = new Vector3(globalVelocity.x, physicsBody.velocity.y, globalVelocity.z);




        Vector2 directionJoystickValue = UiManager.instance.PositionJoystick.Direction;
        if (UiManager.instance.RotationJoystick.Direction.magnitude > 0)
        {
            directionJoystickValue = UiManager.instance.RotationJoystick.Direction;
        }
      
            
        Vector3 LookDirection = new Vector3(directionJoystickValue.x, 0, directionJoystickValue.y);

        Quaternion toRotation = Quaternion.LookRotation(LookDirection.normalized);
        transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, Time.deltaTime * rotationSpeed);
     


        //physicsBody.velocity = transform.forward * speed * UiManager.instance.PositionJoystick.Direction.magnitude;







    }
}
