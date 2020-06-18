using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPortal : MonoBehaviour {

    public Player player;
    public QuestManager questManager;
    private float limit;
    private bool possible;
    public GameObject check;
    private Animator animator;
    public BoxCollider barrier;
    public SphereCollider npcSphere;
    public int zone1;
    public int zone2;

    private void Start() {
        animator = gameObject.GetComponent<Animator>();
        npcSphere = gameObject.GetComponent<SphereCollider>();
        possible = false;
        limit = transform.position.x + 1;
    }

    public void CheckNextLevelBarrier()
    {
        possible = check.activeSelf;

        if (possible)
        {
            barrier.enabled = false;
            npcSphere.enabled = false;
            animator.SetTrigger("Interact");
        }
    }

    public void Update()
    {
        if (possible) return;

        CheckNextLevelBarrier();
    }

    private void OnTriggerExit(Collider other) {
        if(possible && other.CompareTag("Mortdecai")) {
             if(questManager.zone == zone1) {
                    questManager.setZone(zone2);
                } else {
                    questManager.setZone(zone1);
                }
        }
    }
}
