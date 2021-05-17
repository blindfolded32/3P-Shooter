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
        PackSpawn();
        Destroy(this);
        this.gameObject.SetActive(false);
    }

    private void PackSpawn()
    {
        GameObject HP = Instantiate(HP_Pack);
        GameObject Ammo = Instantiate(Ammo_Pack);
        HP.transform.position = Spawner.position;
        Ammo.transform.position = Spawner.position + (Vector3.one * 2);
    }
}
