using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
       //print("HIT"+ other.name);
       // Destroy(gameObject);
        if (other.tag == "SecretButton") Destroy(other.gameObject);
        if (other.tag == "MeleeEnemy") other.GetComponent<Melee_Behaviour>().TakeDamage(5);
    }

}
