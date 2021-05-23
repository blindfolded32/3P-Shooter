using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplosion : MonoBehaviour
{
   // [SerializeField] WallDestroy boom;
    private List<GameObject> Triggered;

    public void OnTriggerEnter(Collider other)
    {
        print("Boom");
     //   boom.DestroyIt();
        gameObject.GetComponent<SphereCollider>().isTrigger=true;
        Triggered.Add(other.gameObject);
        foreach (GameObject Bommbed in Triggered) Bommbed.GetComponent<Rigidbody>().AddForce(new Vector3(Bommbed.transform.position.x * -1, 50, Bommbed.transform.position.z * -1), ForceMode.Impulse);

        Destroy(gameObject);

    }
}
