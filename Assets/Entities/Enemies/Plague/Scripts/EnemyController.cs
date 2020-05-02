using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    GameObject player;
    public NavMeshAgent agent;
    bool playerInTerritory;
    Vector3 initialPosition;

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
        if (playerInTerritory == true)
        {
            agent.SetDestination(player.transform.position);
        }
        else if (!playerInTerritory && !transform.position.Equals(initialPosition))
        {
            agent.SetDestination(initialPosition);
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
