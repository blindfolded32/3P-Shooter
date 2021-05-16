using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
       // print("HIT"+ other.name);
        Destroy(gameObject);
    }
   
}
