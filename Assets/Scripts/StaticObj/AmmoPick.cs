using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPick : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            print("Ammo Up");
            other.GetComponent<PlayerMovement>().GetAmmo(20);
            Destroy(gameObject);
        }

    }
}
