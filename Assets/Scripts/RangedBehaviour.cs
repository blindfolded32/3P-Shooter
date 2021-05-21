using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedBehaviour : MonoBehaviour
{
    private int _currentHP, _bulletsLeft;
    private int _fireDistance = 200;
    public GameObject HP_Pack;
    public GameObject Ammo_pack;
    public Transform Spawner;
    private float _speed = 2;
    private Transform _playerPosition;
    public GameObject BulletPrefab;
    public Transform bulletSpawner;
    public GameObject WeaponPrefab;
    public float FireRate = 3F;
    public float BulletSpeed, LifeTime, NextShot;
    // Start is called before the first frame update
    void Awake()
    {
        _currentHP = 100;
        _bulletsLeft = 15;
    }
    void Start()
    {
        _playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Bullet") _currentHP -= 10;

        if (_currentHP <= 0)
        {
            print("ouch");
            Destroy(gameObject);
            PackSpawn();
        }
    }
    void Update()
    {
        if (Vector3.Distance(transform.position, _playerPosition.position) < _fireDistance)
        {
            rotateToPlayer();
            if (Time.time > FireRate + NextShot)
            {
                NextShot = Time.time + FireRate;
                Shoot();
            }
        }
    }
    private void rotateToPlayer()
    {
        Vector3 relative = _playerPosition.position - transform.position;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, relative, _speed * Time.deltaTime, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDir);
    }
    private void Shoot()
    {
        GameObject Bullet = Instantiate(BulletPrefab);
        Physics.IgnoreCollision(Bullet.GetComponent<Collider>(), bulletSpawner.parent.GetComponent<Collider>());
        Bullet.transform.position = bulletSpawner.position;
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
    private IEnumerator DestroyBullet(GameObject Bullet, float delay)//���������� ������ ����� N ������
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
