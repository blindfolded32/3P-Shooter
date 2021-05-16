using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    
    public GameObject BulletPrefab;
    public Transform Spawner;
    public GameObject WeaponPrefab;
    public float FireRate =30F;
    public float BulletSpeed,LifeTime,NextShot;
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && Time.time > FireRate)
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
        print(Bullet.transform.rotation);
        Bullet.GetComponent<Rigidbody>().AddForce(Spawner.forward * BulletSpeed, ForceMode.Impulse);
        StartCoroutine(DestroyBullet(Bullet, LifeTime));
        
    }
    private IEnumerator DestroyBullet(GameObject Bullet, float delay)//уничтожаем патрон через N секунд
    {
        yield return new WaitForSeconds(delay);
        Destroy(Bullet);
    }
}
