using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RollingBall : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform EndPoint,StartPoint;
    [SerializeField] GameObject Ball;
    private NavMeshAgent _meshAgent;
    GameObject ball;


    // Update is called once per frame
    void Start()
    {
        _meshAgent = GetComponent<NavMeshAgent>();
        _meshAgent.SetDestination(EndPoint.position);
        ball = Instantiate(Ball, StartPoint);

    }
   
    private void OnTriggerEnter(Collider other)
    {
        print(other.name);
        if (other.name == "EndPoint")
        {
          
            StartCoroutine(DestroyBall(ball, 1));

        }
        if (other.CompareTag("Player")) other.GetComponent<PlayerMovement>().TakeDamage(100);
    }

    private IEnumerator DestroyBall(GameObject ball, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(ball);
    }
}
