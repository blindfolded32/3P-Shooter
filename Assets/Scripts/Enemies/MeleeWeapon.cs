using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : MonoBehaviour
{
    [SerializeField] private GameObject _weapon;
    private float NextShot;
    public float FireRate = 0.8f;
    private GameObject _player;
   
    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    
    }
    private void OnTriggerEnter(Collider other)
    {
        print(other.tag);
        if (other.tag == "Player")
        {
            Strike();
        }
    }
    public void Strike()
    {
        
        if (Time.time > FireRate + NextShot)
        {
            NextShot = Time.time + FireRate;
            _player.GetComponent<PlayerMovement>().TakeDamage(20);
            print("HIT");
        }
    }
}
