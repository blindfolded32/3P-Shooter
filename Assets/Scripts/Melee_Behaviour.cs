using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee_Behaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public float HP=100;
    private float _speed = 1;
    public GameObject HP_Pack;
    public GameObject Ammo_pack;
    public Transform Spawner;
    private Transform _playerPosition;
    void Start()
    {
        _playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 relative = _playerPosition.position - transform.position;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, relative, _speed * Time.deltaTime, 0f);
        transform.rotation = Quaternion.LookRotation(newDir);
        transform.position = Vector3.MoveTowards(transform.position, _playerPosition.position,30);
        if (HP <= 0) 
        {
            Destroy(gameObject);
            PackSpawn();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
      

        if (other.tag == "Bullet")
        {
            HP -= 10;
            print("HIT" + HP);
        }
    }

    private void PackSpawn()
    {
        GameObject HP = Instantiate(HP_Pack);
        GameObject Ammo = Instantiate(Ammo_pack);
        HP.transform.position = Spawner.position;
        Ammo.transform.position = Spawner.position + (Vector3.one * 2);
    }
}
