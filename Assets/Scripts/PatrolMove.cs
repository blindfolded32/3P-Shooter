using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolMove : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Transform[] waypoints;
    private Transform _playerPosition;
    private Animator _animator;

    int m_CurrentWaypointIndex;

    void Start()
    {
      //  waypoints[0].position = gameObject.transform.position;
        navMeshAgent.SetDestination(waypoints[0].position);
        _animator = gameObject.GetComponentInChildren<Animator>();
        _playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
       Goto();
        if (Vector3.Distance(transform.position, _playerPosition.position) < 300 * navMeshAgent.radius)
        {
            if (gameObject.tag == "MeleeEnemy") MelleeBeh();

        }
        
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

    void MelleeBeh()
    {   
            print("I see you " + gameObject.name);
            navMeshAgent.SetDestination(_playerPosition.position);
            if (Vector3.Distance(transform.position, _playerPosition.position) <= 100) //* navMeshAgent.radius )
            {
            _animator.SetBool("Attack", true);
            print(_animator.GetBool("Attack"));
               
                //  GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().TakeDamage(0);
            }
        print(_animator.GetBool("Attack"));
        _animator.SetBool("Attack", false);

    }
}
