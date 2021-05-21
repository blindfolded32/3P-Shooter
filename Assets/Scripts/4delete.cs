using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShooting : MonoBehaviour
{
    public GameObject BulletPrefab;
    public Transform Spawner;
    public GameObject WeaponPrefab;
    public float FireRate = 30F;
    public float BulletSpeed, LifeTime, NextShot;
    // Update is called once per frame
    void Update()
    {
        if ( Time.time > FireRate+NextShot)
        {
            NextShot = Time.time + FireRate;
            Shoot();
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
