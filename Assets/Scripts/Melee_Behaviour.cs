using UnityEngine;

public class Melee_Behaviour : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform _enemyTarget;
//    [SerializeField] private NavMeshAgent navMeshAgent;
    public float HP=100;
   // private float _speed = 1;
    public GameObject HP_Pack;
    public GameObject Ammo_pack;
    public Transform Spawner;
    private int _minDistance = 20;
    
    private int _maxDistance = 200;
    private Animator _animator;
    private Transform _playerPosition;


    void Start()
    {
        //_playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
        //_animator = GetComponentInChildren<Animator>();//GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        
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
