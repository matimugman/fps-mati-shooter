using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController characterController;

    public float Speed = 10f;

    public float gravity = 9.81f;


    public Transform GroundCheck;
    public float sphereRadius = 0.3f;
    public LayerMask groundMask;

    bool isGrounded;

    Vector3 velocity;

    public float JumpHeight = 3;

    void Update()
    {


        isGrounded = Physics.CheckSphere(GroundCheck.position,sphereRadius,groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");

        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;


        if (Input.GetKey("space") && isGrounded )
        {
            velocity.y = Mathf.Sqrt(JumpHeight * -2 * gravity);
        }





        characterController.Move(move * Speed * Time.deltaTime);

        velocity.y -= gravity * Time.deltaTime;

        characterController.Move(velocity * Time.deltaTime);

    }
}
