using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee_Behaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public float HP=100;
    public GameObject HP_Pack;
    public GameObject Ammo_pack;
    public Transform Spawner;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0) 
        {
            print("ouch"); 
            this.gameObject.SetActive(false);
            PackSpawn();
           
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        print(collision.collider.name);
        if (collision.collider.CompareTag("Bullet"))
        {
            print("HIT"+ HP);
            HP -= 10;
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
