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
    private BoxCollider boxCollider;
    private bool finished;
    public Vector3 positionToGo;
    public int zoneToGo;

    private void Start() {
        animator = gameObject.GetComponent<Animator>();
        boxCollider = gameObject.GetComponent<BoxCollider>();
        possible = false;
        limit = transform.position.x + 1;
    }

    public void CheckNextLevelBarrier()
    {
        possible = check.activeSelf;

        if (possible)
        {
            boxCollider.enabled = false;
            animator.SetTrigger("Interact");
        }
    }

    public void Update()
    {
        if (finished) return;

        if (possible)
        {
            if (player != null && player.transform.position.x > limit)
            {
                Debug.Log("TELETRANSPORT");
                questManager.setZone(zoneToGo);
                player.transform.position = positionToGo;
                finished = true;
            }
        } else {
            CheckNextLevelBarrier();
        }
    }
}
