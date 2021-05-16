using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestOpen : MonoBehaviour
{
    public GameObject HP_Pack;
    public GameObject Ammo_Pack;
    public Transform Spawner;
    private Animator _animator;
        private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
       _animator.SetBool("Open", true);
       GameObject HP = Instantiate(HP_Pack);
       GameObject Ammo = Instantiate(Ammo_Pack);
        HP.transform.position = Spawner.position;
        Ammo.transform.position = Spawner.position + (Vector3.one*2);
        HP.GetComponent<Rigidbody>().AddForce(new Vector3 (Spawner.position.x, Spawner.position.y, Spawner.position.z ),ForceMode.Acceleration);
        Ammo.GetComponent<Rigidbody>().AddForce(new Vector3(Spawner.position.x , Spawner.position.y , Spawner.position.z ), ForceMode.Acceleration);

        Destroy(this);
        this.gameObject.SetActive(false);

    }
}
