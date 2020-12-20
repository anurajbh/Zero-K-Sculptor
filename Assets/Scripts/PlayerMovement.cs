using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController characterController;

    public float speed = 12f;

    public bool isSprinting = false;

    public float sprintBoost = 1.5f;//how much sprint should boost speed

    public float grav = -9.81f;

    public bool isGrounded = true;

    public GameObject groundCheck;

    public LayerMask groundMask;

    public float groundDistance = 0.1f;

    public float jumpHeight = 40f;

    Vector3 groundVelocity;//jump and fall velocity
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        groundCheck = GameObject.Find("GroundCheck");
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfSprint();
        MovePlayer();
    }
    private void CheckIfSprint()
    {
        if(Input.GetAxisRaw("Fire3")!=0)
        {
            isSprinting = true;
        }
        else
        {
            isSprinting = false;
        }
    }
    private void MovePlayer()
    {
        isGrounded = Physics.CheckSphere(groundCheck.transform.position, groundDistance, groundMask);
        if(isGrounded && groundVelocity.y <0)
        {
            groundVelocity.y = -2f;
        }
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        if (!isSprinting)
        {
            characterController.Move(move * speed * Time.deltaTime);
        }
        else
        {
            characterController.Move(move * speed * Time.deltaTime * sprintBoost);
        }
        if(Input.GetAxisRaw("Jump")!=0 && isGrounded)
        {
            groundVelocity.y = Mathf.Sqrt(-2f*grav * jumpHeight);
        }
        groundVelocity.y += grav * Time.deltaTime;
        characterController.Move(groundVelocity * Time.deltaTime);
    }
}
