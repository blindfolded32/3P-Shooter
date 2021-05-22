using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Melee_Behaviour : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform _enemyTarget;
    [SerializeField] private NavMeshAgent navMeshAgent;
    public float HP=100;
   // private float _speed = 1;
    public GameObject HP_Pack;
    public GameObject Ammo_pack;
    public Transform Spawner;
    private int _minDistance = 20;
    private int _maxDistance = 200;

    private Transform _playerPosition;


   /* private void Awake()
    {
       // _enemyTarget = GameObject.FindGameObjectWithTag("Player").transform;
        //navMeshAgent.SetDestination(_enemyTarget.position);
    }*/
    void Start()
    {
        _playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
       
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Vector3.Distance(transform.position, _playerPosition.position) > _minDistance && Vector3.Distance(transform.position, _playerPosition.position) < _maxDistance) { print("I see you "+ gameObject.name); navMeshAgent.SetDestination(_playerPosition.position); }
        /*  {
              Vector3 relative = _playerPosition.position - transform.position;
              Vector3 newDir = Vector3.RotateTowards(transform.forward, relative, _speed * Time.deltaTime, 0f);
              transform.rotation = Quaternion.LookRotation(newDir);
              transform.position = Vector3.MoveTowards(transform.position, _playerPosition.position, 0.2f);
          }*/

    }
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
