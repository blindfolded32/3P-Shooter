using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretButton : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject Trap;
    [SerializeField] GameObject Safe;

    private void OnCollisionEnter(Collision collision)
    {
        Trap.SetActive(false);
        GameObject SafeOn = Instantiate(Safe);
    }
    private void OnTriggerEnter(Collider other)
    {
        Trap.SetActive(false);
        GameObject SafeOn = Instantiate(Safe);
    }
}
