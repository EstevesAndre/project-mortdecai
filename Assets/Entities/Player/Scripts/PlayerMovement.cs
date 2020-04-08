using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    private Input controls;
    private Vector2 movementInput;

    private void Awake() {
        controls = new Input();
        controls.Player2D.Movement.performed += ctx => movementInput = ctx.ReadValue<Vector2>();
        controls.Player2D.Jump.performed += _ => Jump();
    }

    void Update() {
        Debug.Log("Move: " + movementInput);
    }

    private void Jump() {
        Debug.Log("Jump!");
    }

    void OnEnable() {
        controls.Enable();
    }

    void OnDisable() {
        controls.Disable();
    }
}
