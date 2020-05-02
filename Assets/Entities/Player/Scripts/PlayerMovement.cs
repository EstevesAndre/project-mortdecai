using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour {
    private Input controls;
    private Vector2 movementInput;
    public Rigidbody rb;
    public bool isPlaying = false;

    public Vector3 velocity;
    public float gravity = -9.81f;
    public float speed = 12f;

    public Transform groundCheck;
    public float groundDistance = 0.1f;
    public LayerMask groundMask;
    private bool isGrounded;

    public float jumpHeight = 3f;

    private void Awake() {
        controls = new Input();
        controls.Player2D.Movement.performed += ctx => movementInput = ctx.ReadValue<Vector2>();
        controls.Player2D.Jump.performed += _ => Jump();
    }

    void Update() {
        velocity.x = 0f;

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0) {
            velocity.y = -2f;
        }

        if (isPlaying) {
            float x = movementInput.x;
            velocity.x = x * speed;
        }

        if (!isGrounded) {
            velocity.y += gravity * Time.deltaTime;
        }
    }

    void FixedUpdate() {
        rb.velocity = velocity;
    }

    private void Jump() {
        if (isGrounded && isPlaying) {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }

    public void TogglePlaying() {
        isPlaying = !isPlaying;
    }

    void OnEnable() {
        controls.Enable();
    }

    void OnDisable() {
        controls.Disable();
    }
}
