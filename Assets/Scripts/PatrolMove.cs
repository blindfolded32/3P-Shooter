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
    private int HGMask;

    int m_CurrentWaypointIndex;

    void Start()
    {
      //  waypoints[0].position = gameObject.transform.position;
        navMeshAgent.SetDestination(waypoints[0].position);
        _animator = gameObject.GetComponentInChildren<Animator>();
        _playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
        HGMask = 3 << NavMesh.GetAreaFromName("HG");
    }

    void Update()
    {
       Goto();
        if (Vector3.Distance(transform.position, _playerPosition.position) < 300 * navMeshAgent.radius)
        {
            if (gameObject.tag == "MeleeEnemy") MelleeBeh();
            else RangeBeh();
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

    void RangeBeh()
    {
        if (Vector3.Distance(transform.position, _playerPosition.position) < 300)
        {
            //  _navMesh.SetDestination(_HighPos.position);
            //navMeshAgent.SamplePathPosition(NavMesh.GetAreaFromName("HG"), 300, out NavMeshHit _hit);
            NavMesh.FindClosestEdge(gameObject.transform.position, out NavMeshHit _hit, 3);
            navMeshAgent.SetDestination(_hit.position);
            print("going" + navMeshAgent.destination + "hit" + _hit.position);
        }
    }

    void MelleeBeh()
    {   
            //print("I see you " + gameObject.name);
            navMeshAgent.SetDestination(_playerPosition.position);
            if (Vector3.Distance(transform.position, _playerPosition.position) <= 100) //* navMeshAgent.radius )
            {
            gameObject.GetComponentInChildren<Animator>().SetBool("Attack", true);
            print(_animator.GetBool("Attack")+ "name"+ _animator.name);
               
                //  GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().TakeDamage(0);
            }
        //print(_animator.GetBool("Attack"));
        else gameObject.GetComponentInChildren<Animator>().SetBool("Attack", false);

    }
}
