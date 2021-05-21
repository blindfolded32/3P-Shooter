using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPPick : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (gameObject.tag == "SmallHpPack") other.GetComponent<PlayerMovement>().RestoreHP(20);
            else other.GetComponent<PlayerMovement>().RestoreHP(50);

            Destroy(gameObject);
        }

    }
}
