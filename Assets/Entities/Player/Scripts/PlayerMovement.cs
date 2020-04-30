using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

public class PlayerMovement : MonoBehaviour
{
    #region Fields

    private Input controls;
    private Vector2 movementInput;
    public Rigidbody rb;
    public bool isPlaying = false;

    private float jumpInput;
    public CharacterController characterController;

    private Vector3 velocity;
    public float gravity = -9.81f;
    public float speed = 12f;
    private Animator animator;

    public Transform groundCheck;
    public float groundDistance = 0.1f;
    public LayerMask groundMask;
    private bool isGrounded;
    public float jumpHeight = 3f;

    private NavMeshAgent agent;
    public float playerDistance = 2f;
    public LayerMask playerMask;
    public Transform otherPlayer;


    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        Physics.IgnoreCollision(GetComponent<Collider>(), otherPlayer.GetComponent<Collider>(), true);
        controls = new Input();
        controls.Player2D.Movement.performed += ctx => movementInput = ctx.ReadValue<Vector2>();
        controls.Player2D.Jump.performed += _ => Jump();
        jumpInput = velocity.y;
    }

    void Update()
    {
        if (isPlaying)
        {
            velocity.x = 0f;

            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
                animator.SetBool("Falling", false);
            }
            else if (!isGrounded && velocity.y < 0)
            {
                animator.SetBool("Jumping", false);
                animator.SetBool("Falling", true);
            }

            float x = movementInput.x;
            velocity.x = x * speed;
            animator.SetFloat("Speed", Math.Abs(velocity.x));

            if (!isGrounded)
            {
                velocity.y += gravity * Time.deltaTime;
            }
        }
        else
        {
            bool isClose = Physics.CheckSphere(transform.position, playerDistance, playerMask);

            if (!isClose)
            {
                agent.SetDestination(otherPlayer.position);
            }
            else if (!agent.isStopped)
            {
                agent.isStopped = true;
                agent.ResetPath();
            }
        }
    }

    void FixedUpdate()
    {
        if (isPlaying)
        {
            Vector3 direction = Vector3.right * Math.Sign(velocity.x);
            if (direction != Vector3.zero)
            {
                rb.rotation = Quaternion.LookRotation(direction);
            }
            rb.velocity = velocity;
        }
    }

    private void Jump()
    {
        if (isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            animator.SetBool("Jumping", true);
        }
    }

    public void TogglePlaying()
    {
        isPlaying = !isPlaying;
        agent.enabled = !agent.enabled;
    }

    void OnEnable()
    {
        controls.Enable();
    }

    void OnDisable()
    {
        controls.Disable();
    }

    public Vector2 GetMovement()
    {
        return movementInput;
    }

    public float GetJump()
    {
        return jumpInput;
    }

    public Input GetControls()
    {
        return controls;
    }
    #endregion

}

