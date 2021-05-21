using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    
    public GameObject BulletPrefab;
    public Transform Spawner;
    public float BulletSpeed,LifeTime,NextShot, FireRate,ReloadTime;
    private int _bulletsIn=10;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && Time.time > NextShot)
        {
            NextShot = Time.time + FireRate;
            WeaponRotate();
            
            Shoot();
        }
    }
    private void WeaponRotate()
    { }
    private void Shoot()
    {
        GameObject Bullet = Instantiate(BulletPrefab);
        Physics.IgnoreCollision(Bullet.GetComponent<Collider>(), Spawner.parent.GetComponent<Collider>());
        Bullet.transform.position = Spawner.position;
        Vector3 rotation = Bullet.transform.rotation.eulerAngles;
        Bullet.transform.rotation = Quaternion.Euler(rotation.x, transform.eulerAngles.y, rotation.z);
        Bullet.GetComponent<Rigidbody>().AddForce(Spawner.forward * BulletSpeed, ForceMode.Impulse);
        StartCoroutine(DestroyBullet(Bullet, LifeTime));
        _bulletsIn--;
        if (_bulletsIn == 0)
        {
            NextShot += 2;
            _bulletsIn = 10;
        }
    }
    private IEnumerator DestroyBullet(GameObject Bullet, float delay)//уничтожаем патрон через N секунд
    {
        yield return new WaitForSeconds(delay);
        Destroy(Bullet);
    }

    
}
