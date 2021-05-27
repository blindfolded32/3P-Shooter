using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class RangedBehaviour : MonoBehaviour
{
    private int _currentHP, _bulletsLeft ;
    public GameObject HP_Pack;
    public GameObject Ammo_pack;
    public Transform Spawner;
    private float _speed = 2;
    private Transform _playerPosition;
    private Animator _animator;
    public GameObject BulletPrefab;
    public Transform bulletSpawner;
    public GameObject WeaponPrefab;

    public float BulletSpeed, LifeTime, NextShot, FireRate, _fireDistance;
   
    // Start is called before the first frame update
    void Awake()
    {
        _currentHP = 100;
        _bulletsLeft = 15;
    }
    void Start()
    {
        _playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
        _animator = gameObject.GetComponent<Animator>();
       //_HighPos = GameObject.FindGameObjectWithTag("HighGround").transform;
   
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Bullet") _currentHP -= 10;

        if (_currentHP <= 0)
        {
           // print("ouch");
            Destroy(gameObject);
            PackSpawn();
        }
    }
    void Update()
    {
        _animator.SetBool("Move", true);
        if (Vector3.Distance(transform.position, _playerPosition.position) < _fireDistance)
        {  
            rotateToPlayer();
            _animator.SetBool("Shot", true);
        }
        else _animator.SetBool("Shot", false);
    }
    private void rotateToPlayer()
    {
        Vector3 relative = _playerPosition.position - transform.position;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, relative, _speed * Time.deltaTime, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDir);
    }
    private void Shoot()
    {
       // print("pif");
        if (Time.time > FireRate + NextShot)
        {
            NextShot = Time.time + FireRate;

            GameObject Bullet = Instantiate(BulletPrefab);
            Physics.IgnoreCollision(Bullet.GetComponent<Collider>(), bulletSpawner.parent.GetComponent<Collider>());
            Bullet.transform.position = bulletSpawner.position;
            // print("Shot from" + Bullet.transform.position);
            Vector3 rotation = Bullet.transform.rotation.eulerAngles;
            Bullet.transform.rotation = Quaternion.Euler(rotation.x, rotation.y, rotation.z);
            Bullet.GetComponent<Rigidbody>().AddForce(bulletSpawner.forward * BulletSpeed, ForceMode.Impulse);
            StartCoroutine(DestroyBullet(Bullet, LifeTime));
            _bulletsLeft--;
            if (_bulletsLeft == 0)
            {
                NextShot += 2;
                _bulletsLeft = 30;
            }
        }
    }
    private IEnumerator DestroyBullet(GameObject Bullet, float delay)//уничтожаем патрон через N секунд
    {
        yield return new WaitForSeconds(delay);
        Destroy(Bullet);
    }
    private void PackSpawn()
    {
        GameObject HP = Instantiate(HP_Pack);
        GameObject Ammo = Instantiate(Ammo_pack);
        HP.transform.position = Spawner.position;
        Ammo.transform.position = Spawner.position + (Vector3.one * 2);
    }
}
