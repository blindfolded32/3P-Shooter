using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    private AudioSource _audio;

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
        _audio.Play();
    }
    private void OnTriggerEnter(Collider other)
    {      
       //print("HIT"+ other.name);
        if (other.tag == "SecretButton") Destroy(other.gameObject);
         if (other.tag == "MeleeEnemy") other.GetComponent<Melee_Behaviour>().TakeDamage(5);
        if (other.tag == "RangeEnemy") other.GetComponent<RangedBehaviour>().TakeDamage(5);
        Destroy(gameObject);
        
    }

    

}
