using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController characterController;

    public float speed = Mathf.Clamp(12f, 0f, 1000f);
    private float maxSpeed;
    public bool isSprinting = false;

    public float sprintBoost = Mathf.Clamp(1.5f, 1f, 3f);//how much sprint should boost speed
    private float maxSprint;
    public float grav = -9.81f;

    public bool isGrounded = true;

    public GameObject groundCheck;

    public LayerMask groundMask;

    public float groundDistance = 0.1f;

    public float jumpHeight = Mathf.Clamp(40f,0f,4000f);
    private float maxJump;
    Vector3 groundVelocity;//jump and fall velocity
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        groundCheck = GameObject.Find("GroundCheck");
        maxSpeed = speed;
        maxSprint = sprintBoost;
        maxJump = jumpHeight;
        InvokeRepeating("SlowPlayer", 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfSprint();
        MovePlayer();
    }

    private void SlowPlayer()
    {
        speed = TimeProgression.Instance.SlowDownGame(speed, maxSpeed);
        sprintBoost = TimeProgression.Instance.SlowDownGame(sprintBoost, maxSprint);
        jumpHeight = TimeProgression.Instance.SlowDownGame(jumpHeight, maxJump);
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
