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
        gameObject.GetComponent<BoxCollider>().enabled = false;
        gameObject.GetComponent<SphereCollider>().enabled = true;
    }
    private void OnTriggerStay(Collider other)
    {
        
    
        //gameObject.GetComponent<SphereCollider>().isTrigger =true;
        // Triggered.Add(other.gameObject);
        // foreach (GameObject Bommbed in Triggered) 
        if (other.tag != "Bullet")
        {
            other.GetComponent<Rigidbody>().AddForce(new Vector3 (gameObject.transform.position.x, 550,gameObject.transform.position.z) *10, ForceMode.Impulse);
            print(other.name + " " + other.GetComponent<Rigidbody>().velocity);
        }
        Destroy(gameObject);

    }
}
