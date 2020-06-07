using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour, IInteractable {

    private Animator animator;
    private bool isOn;
    public GameObject barrier;
    private void Start() {
        animator = gameObject.GetComponent<Animator>();   
        isOn = false;
    }

    public void Interact() {
        if (!isOn) {
            animator.SetTrigger("Interact");
            isOn = !isOn;
            barrier.GetComponent<Barrier>().Interact();
        }
    }

}
