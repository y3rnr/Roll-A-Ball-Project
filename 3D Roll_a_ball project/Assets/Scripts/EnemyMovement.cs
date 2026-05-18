using UnityEngine;
using UnityEngine.AI; // we need to include this namespace to use the NavMeshAgent component

public class EnemyMovement : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent navMeshAgent;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>(); // get the NavMeshAgent component attached to the enemy
    }
        
    void Update()
    {
        if (navMeshAgent != null) // check if the NavMeshAgent component is not null
        {
            navMeshAgent.SetDestination(player.position); // set the destination of the NavMeshAgent to the player's position
        }
    }
}