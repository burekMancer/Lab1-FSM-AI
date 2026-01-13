using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using NUnit.Framework;

public class GuardPatrol : MonoBehaviour
{

    NavMeshAgent agent;

    [SerializeField] private Transform player;
    [SerializeField] private List<Transform> waypoints = new List<Transform>(4);
    int currentwaypoint = 0;

    enum GuardState
    {
        Patrolling,
        Chasing,
        Returning
    }

    GuardState state = GuardState.Patrolling;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case GuardState.Patrolling:
                if(!agent.pathPending && agent.remainingDistance < 7f) {
                    agent.SetDestination(waypoints[currentwaypoint].position);
                    currentwaypoint = (currentwaypoint + 1) % waypoints.Count;
                }
                break;
            case GuardState.Chasing:
                while(agent.remainingDistance >30f)
                {agent.SetDestination(player.position);}
                break;
            case GuardState.Returning:
                if (agent.remainingDistance < 40f)
                {
                    Debug.Log("Returned to patrol.");
                    state = GuardState.Patrolling;
                }
                break;
        }
        
    }


     private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player detected!");
            state = GuardState.Chasing;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player lost!");
            state = GuardState.Returning;
            agent.SetDestination(waypoints[currentwaypoint].position);
        }
    }
}