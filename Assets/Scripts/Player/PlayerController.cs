using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundMask;
    
    private CharacterController controller;
    
    private float speed = 4f;
    private Vector3 velocity;
    private bool isGrounded;

    void Start()
    {
        controller = transform.GetComponent<CharacterController>();
    }

    void Update()
    {
        CheckGround();
        AddGravity();

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
    
    private void CheckGround()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.2f, groundMask);
    }
    
    void AddGravity()
    {
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -0.5f;
        }
        else
        {
            velocity.y += (Physics.gravity.y * 1.2f) * Time.deltaTime;
        }

        velocity.y = Mathf.Clamp(velocity.y, -10, 5);
    }
}
