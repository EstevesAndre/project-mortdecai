using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    GameObject player;
    bool playerInTerritory;
    Vector3 initialPosition;
    public float speed;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
        player = GameObject.FindGameObjectWithTag("Player");
        playerInTerritory = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInTerritory == true && Vector3.Distance(transform.position, player.transform.position) > 1f)
        {
            animator.SetFloat("speed", 1);
            transform.LookAt(new Vector3(player.transform.position.x,0,0));
            transform.position += transform.forward*speed*Time.deltaTime;
        }
        else if (!playerInTerritory && Vector3.Distance(initialPosition, transform.position) > 1f)
        {
            animator.SetFloat("speed", 1);
            transform.LookAt(initialPosition);
            transform.position += transform.forward*speed*Time.deltaTime;
        }
        else {
            animator.SetFloat("speed", 0);
        }
    }
    
    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject == player)
        {
            playerInTerritory = true;
        }
    }

    void OnTriggerExit (Collider other)
    {
        if (other.gameObject == player) 
        {
            playerInTerritory = false;
        }
    }
}
