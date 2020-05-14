using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpMushroom : MonoBehaviour {

    private Animator animator;

    private void Start() {
        animator = gameObject.GetComponent<Animator>();   
    }

    void OnTriggerEnter(Collider other) {
        animator.SetTrigger("activated");
        //other.gameObject.GetComponent<Rigidbody>().AddForce(100*transform.up,ForceMode.VelocityChange);
        other.gameObject.transform.position += 300 * Vector3.up * Time.deltaTime;
    }
}
