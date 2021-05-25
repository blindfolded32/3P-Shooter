using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplosion : MonoBehaviour
{
   // [SerializeField] WallDestroy boom;
    private List<GameObject> Triggered;

    public void OnTriggerEnter(Collider other)
    {
      
     //   boom.DestroyIt();
        gameObject.GetComponent<SphereCollider>().isTrigger=true;
        gameObject.GetComponent<BoxCollider>().enabled = false;
        // Triggered.Add(other.gameObject);
        // foreach (GameObject Bommbed in Triggered) 
        if (other.tag != "Bullet")
        {
            other.GetComponent<Rigidbody>().AddForce(new Vector3(other.transform.position.x * -100, 50, other.transform.position.z * -10), ForceMode.VelocityChange);
            print(other.name + " " + other.GetComponent<Rigidbody>().velocity);
        }
        //Destroy(gameObject);

    }
}
