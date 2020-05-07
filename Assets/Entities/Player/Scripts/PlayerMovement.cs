using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour {
    private Input controls;
    private Vector2 movementInput;
    public Rigidbody rb;
    public bool isPlaying = false;

    private Vector3 velocity;
    public float gravity = -9.81f;
    public float speed = 12f;

    public Transform groundCheck;
    public float groundDistance = 0.1f;
    public LayerMask groundMask;
    private bool isGrounded;

    public float jumpHeight = 3f;

    private NavMeshAgent agent;
    public float playerDistance = 2f;
    public LayerMask playerMask;
    public Transform otherPlayer;

    private void Awake() {
        agent = GetComponent<NavMeshAgent>();
        controls = new Input();
        controls.Player2D.Movement.performed += ctx => movementInput = ctx.ReadValue<Vector2>();
        controls.Player2D.Jump.performed += _ => Jump();
    }

    void Update() {
        if (isPlaying) {
            velocity.x = 0f;

            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
            if (isGrounded && velocity.y < 0) {
                velocity.y = -2f;
            }

            float x = movementInput.x;
            velocity.x = x * speed;

            if (!isGrounded) {
                velocity.y += gravity * Time.deltaTime;
            }
        } else {
            bool isClose = Physics.CheckSphere(transform.position, playerDistance, playerMask);

            if (!isClose) {
                agent.SetDestination(otherPlayer.position);
            } else if (!agent.isStopped) {
                agent.isStopped = true;
                agent.ResetPath();
            }
        }
    }

    void FixedUpdate() {
        if (isPlaying) {
            rb.velocity = velocity;
        }
    }

    private void Jump() {
        if (isGrounded) {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }

    public void TogglePlaying() {
        isPlaying = !isPlaying;
        agent.enabled = !agent.enabled;
    }

    void OnEnable() {
        controls.Enable();
    }

    void OnDisable() {
        controls.Disable();
    }
}
