using UnityEngine;

public class Melee_Behaviour : MonoBehaviour
{
  
    [SerializeField] private Transform _enemyTarget;
    public float HP=100;
    public GameObject HP_Pack,Ammo_pack;
    public Transform Spawner;
public void TakeDamage(int damage)
    {
        HP -= damage;
        if (HP <= 0)
        {
            Destroy(gameObject);
            PackSpawn();
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
