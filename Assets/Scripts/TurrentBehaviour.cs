using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurrentBehaviour : MonoBehaviour
{
    private float _fireDistance = 300;
    private float _speed = 1;
    private Transform _playerPosition;
    public GameObject BulletPrefab;
    public Transform Spawner;
    public GameObject WeaponPrefab;
    public float FireRate = 3F;
    public float BulletSpeed, LifeTime, NextShot;


    void Start()
    {
        _playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position,_playerPosition.position)< _fireDistance)
        {
           Vector3 relative = _playerPosition.position - transform.position;
           Vector3 newDir = Vector3.RotateTowards(transform.forward, relative*-1, _speed * Time.deltaTime, 0f);           
           transform.rotation = Quaternion.LookRotation(newDir);

            if (Time.time > FireRate + NextShot)
            {
                NextShot = Time.time + FireRate;
                Shoot();
            }
        }
       
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

    }
    private IEnumerator DestroyBullet(GameObject Bullet, float delay)//уничтожаем патрон через N секунд
    {
        yield return new WaitForSeconds(delay);
        Destroy(Bullet);
    }


}
