using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviour : MonoBehaviour
{

   
    public float HP = 100;
    private float _speed = 1;
    private Transform _playerPosition;
    [SerializeField] private Transform Hand;
    [SerializeField] private GameObject BossShield;
    private int _PhaseDuration=15;
    //For mellee
    private int _minDistance = 20;
    private int _maxDistance = 200;
    public GameObject melleeWeaponPrefab;
    //For range
    public GameObject BulletPrefab;
    public Transform Spawner;
    public GameObject rangeWeaponPrefab;
    public float FireRate;
    public float fireDistance = 300F;
    public float BulletSpeed, LifeTime, NextShot,NextPhase;
    private int _bulletsLeft = 300;

    // Start is called before the first frame update
    void Start()
    {
        _playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
       
    }

    void Update()
    {
        if (HP <= 0) Destroy(gameObject);
        if (!GameObject.FindGameObjectWithTag("BossShield"))
        {
            if (!rangeWeaponPrefab.activeSelf) rangeWeaponPrefab.SetActive(true);
            melleeWeaponPrefab.SetActive(false);
            rangePhase();
          //  print("i'm range");
            if (Time.time > _PhaseDuration + NextPhase)
            {
                NextPhase = Time.time + _PhaseDuration;
                Instantiate(BossShield, Hand);
            }
        }
        else
        {
            if (!melleeWeaponPrefab.activeSelf) melleeWeaponPrefab.SetActive(true);
            rangeWeaponPrefab.SetActive(false);
            MelleePhase();
    } 
    }
    private void rotateToPlayer()
    {
        Vector3 relative = _playerPosition.position - transform.position;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, relative , _speed * Time.deltaTime, 0f);
        transform.rotation = Quaternion.LookRotation(newDir);
    }
    private void moveToPlayer()
    {
        if (Vector3.Distance(transform.position, _playerPosition.position) > _minDistance && Vector3.Distance(transform.position, _playerPosition.position) < _maxDistance)
        {
            Vector3 relative = _playerPosition.position - transform.position;
            Vector3 newDir = Vector3.RotateTowards(transform.forward, relative, _speed * Time.deltaTime, 0f);
            transform.rotation = Quaternion.LookRotation(newDir);
            transform.position = Vector3.MoveTowards(transform.position, _playerPosition.position, 0.2f);
        }
    }
    private void rangePhase()
    {
        if (Vector3.Distance(transform.position, _playerPosition.position) < fireDistance)
        {
            rotateToPlayer();
            if (Time.time > FireRate + NextShot)
            {
                NextShot = Time.time + FireRate;
                Shoot();
            }
        }
    }
    private void MelleePhase()
    {
        rotateToPlayer();
        moveToPlayer();
    }
    private void Shoot()
    {
        GameObject Bullet = Instantiate(BulletPrefab);
        Physics.IgnoreCollision(Bullet.GetComponent<Collider>(), Spawner.parent.GetComponent<Collider>());        
       Bullet.transform.position = Spawner.position;
        Vector3 rotation = Bullet.transform.rotation.eulerAngles;
        Bullet.transform.rotation = Quaternion.Euler(rotation.x, rotation.y, rotation.z);
        Bullet.GetComponent<Rigidbody>().AddForce(Spawner.forward * BulletSpeed, ForceMode.Impulse);
        StartCoroutine(DestroyBullet(Bullet, LifeTime));
        _bulletsLeft--;
        if (_bulletsLeft == 0)
        {
            NextShot += 2;
            _bulletsLeft = 30;
        }
    }
    private IEnumerator DestroyBullet(GameObject Bullet, float delay)//уничтожаем патрон через N секунд
    {
        yield return new WaitForSeconds(delay);
        Destroy(Bullet);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            HP -= 2;
            print("Boss HP " +HP);
        }
    }
}
