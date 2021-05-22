using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolMove : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Transform[] waypoints;

    int m_CurrentWaypointIndex;

    void Start()
    {
      //  waypoints[0].position = gameObject.transform.position;
        navMeshAgent.SetDestination(waypoints[0].position);
    }

    void Update()
    {
       Goto();
    }

    void Goto()
    {
        if (navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
        {
            // print("going to "+ waypoints[m_CurrentWaypointIndex].name);
            m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % waypoints.Length;
            navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);
        }
    }
}
