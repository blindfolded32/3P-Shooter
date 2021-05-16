using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingBall : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject ball;
    public Transform Spawner;


    // Update is called once per frame
    void Start()
    {
       /* Vector3 relative = _playerPosition.position - transform.position;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, relative * -1, _speed * Time.deltaTime, 0f);
        transform.rotation = Quaternion.LookRotation(newDir);*/
      //  ball.GetComponent<Rigidbody>().AddForce(new Vector3(1,1,1), ForceMode.Impulse);
        ball.GetComponent<Rigidbody>().AddForce(new Vector3(Spawner.position.x *50, 0, Spawner.position.z*30), ForceMode.Impulse);

       // ball.GetComponent<Rigidbody>().velocity = new Vector3(Spawner.position.x * 3, Spawner.position.y * 1, Spawner.position.z * 6);

    }
    private void Update()
    {
        ball.GetComponent<Rigidbody>().AddForce(new Vector3(Spawner.position.x, 0, Spawner.position.z), ForceMode.Impulse);
    }
    private void OnCollisionEnter(Collision collision)
    {
      //  print("collision with" + collision.collider.name);
        // ball.GetComponent<Rigidbody>().AddForce(ball.transform.right, ForceMode.Impulse);
        ball.GetComponent<Rigidbody>().AddForce(new Vector3(Spawner.position.x , -10, Spawner.position.z ), ForceMode.Impulse);
    }
}
