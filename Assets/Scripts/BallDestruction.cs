using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDestruction : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            print("Rolled");
            Destroy(other.gameObject);
        }
    }
}
