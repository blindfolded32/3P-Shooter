using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava_death : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<PlayerMovement>().TakeDamage(100);
    }
}
