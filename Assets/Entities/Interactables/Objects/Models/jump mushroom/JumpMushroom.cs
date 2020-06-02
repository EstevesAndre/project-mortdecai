using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpMushroom : MonoBehaviour {

    private Animator animator;
    public float force = 1;

    private void Start() {
        animator = gameObject.GetComponent<Animator>();   
    }

    void OnTriggerEnter(Collider other) {
        animator.SetTrigger("activated");
        other.gameObject.GetComponent<PlayerMovement>().MushroomJump(force);
    }

}
