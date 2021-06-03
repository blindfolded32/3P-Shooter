using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    private Animator _animator;
    public GameObject lefrDoor, rightDoor;
    private ParticleSystem leftPS,rightPS;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        leftPS = lefrDoor.GetComponent<ParticleSystem>();
        rightPS = rightDoor.GetComponent<ParticleSystem>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _animator.SetBool("Open", true);
            leftPS.Play();
            rightPS.Play();
        }
    }
}
