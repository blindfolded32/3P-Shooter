using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretButton : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject Trap;
    [SerializeField] GameObject Safe;
    private int counter;

    private void Awake()
    {

    }

    private void Update()
    {
        if (GameObject.FindGameObjectsWithTag("SecretButton").Length == 0) DisableTrap();
    }

    /* private void OnTriggerEnter(Collider other)
     {
         Destroy(gameObject);
         counter--;
         print("Destroy"+counter+"more");
         if (counter <= 0) { print("KABOOM"); DisableTrap(); }
     }*/

    private void DisableTrap()
    {
        //Trap.SetActive(false);
        Destroy(Trap);
        GameObject SafeOn = Instantiate(Safe);
    }
}
