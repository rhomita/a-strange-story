using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private float speed = 4f;
    private Vector3 velocity;

    void Start()
    {
        controller = transform.GetComponent<CharacterController>();
    }

    void Update()
    {
        GetInput();
    }

    void FixedUpdate()
    {
        MakeMovement();
    }

    void GetInput()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        velocity.x = horizontal;
        velocity.z = vertical;
    }

    private void MakeMovement()
    {
        Vector3 forward = transform.forward.normalized;
        Vector3 right = transform.right.normalized;
        forward.y = 0;
        right.y = 0;
        Vector3 movement = forward * velocity.z + right * velocity.x;

        bool isRunning = Vector3.Magnitude(movement) > 0;

        movement.y = velocity.y;

        float _speed = speed;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _speed *= 1.7f;
        }
        controller.Move(movement * (_speed * Time.fixedDeltaTime));
    }
}
