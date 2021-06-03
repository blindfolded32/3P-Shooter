using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public HealthBar healthBar;
    public AmmoText ammoText;
    //
    private Rigidbody PlayerRB;
    private int _maxHP = 100;    
    private int _currentHP,_currentAmmo;
    private CharacterController _MovementControl;
    private Vector3 _MoveDirection = Vector3.zero;
    public float MoveSpeed,JumpThrust,GravityForce,RotateSpeed;
    private Animator _animator;
    //
    public GameObject BulletPrefab;
    public Transform Spawner;
    public float BulletSpeed, LifeTime, NextShot, FireRate, ReloadTime;
    private int _bulletsIn = 10;

    private bool stopped = false;
    private AudioSource _stepSound;
    //
    private void Awake()
    {
        _currentHP = _maxHP;
        _currentAmmo = 100;
        healthBar.SetMaxHealth(_maxHP);
        ammoText.PrintAmmo(_bulletsIn, _currentAmmo);
        _stepSound = GetComponent<AudioSource>();
    }
    void Start()
    {
        PlayerRB = GetComponent<Rigidbody>();
        _MovementControl = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
       Cursor.lockState = CursorLockMode.Locked;
    }
    // Update is called once per frame
    void Update()  
    {
        if (stopped) return;
        else
        {
            Movement();
            if (Input.GetKeyDown(KeyCode.F) && Time.time > NextShot)
            {
                _animator.SetBool("Shot", true);
                NextShot = Time.time + FireRate;
                print(_animator.GetBool("Shot"));
            }
        }
    }
    private void Movement()
    {
        _stepSound.Play();
        if (_MovementControl.isGrounded)
        {
            _animator.SetBool("Move", true);
            
            _MoveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            _MoveDirection = transform.TransformDirection(_MoveDirection) * -1;
            _MoveDirection *= MoveSpeed;
            
            if (Input.GetButton("Jump"))
            {
                _animator.SetBool("Move", false);
                _animator.SetBool("Jump",true);
                _MoveDirection.y = JumpThrust;
                _MoveDirection.x /= 2;
                _MoveDirection.z /= 2;
            }
            _animator.SetBool("Jump", false);
            if (_MoveDirection == Vector3.zero) _animator.SetBool("Move", false);
        }
        _MoveDirection.y -= GravityForce * Time.deltaTime * PlayerRB.mass * PlayerRB.mass;
        _MovementControl.Move(_MoveDirection * Time.deltaTime);
        transform.Rotate(0, Input.GetAxis("Horizontal"), 0);
        
    }
    public void TakeDamage(int damage)
    {
        _currentHP -= damage;
        healthBar.SetHealth(_currentHP);
        if (_currentHP <= 0) { Destroy(gameObject); }
    }
    public void GetAmmo(int bullet)
    {
        _currentAmmo += bullet;
        ammoText.PrintAmmo(_bulletsIn, _currentAmmo);
    }
    public void RestoreHP(int HP)
    {
        _currentHP = Mathf.Clamp(_currentHP + HP,0,100);
        healthBar.SetHealth(_currentHP);
    }
    private void Shoot()
    {
        if (_currentAmmo > 0)
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
                _currentAmmo-=10;
            }
        }
        _animator.SetBool("Shot", false);
        ammoText.PrintAmmo(_bulletsIn, _currentAmmo);
        print(_animator.GetBool("Shot"));
    }
    private IEnumerator DestroyBullet(GameObject Bullet, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(Bullet);
    }

    public bool Stop(bool value) => stopped = value;

}
