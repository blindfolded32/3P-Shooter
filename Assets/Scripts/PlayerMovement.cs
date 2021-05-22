using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody PlayerRB;
    private int _maxHP = 100;    
    private int _currentHP,_currentAmmo,_bulletIn;
    private CharacterController _MovementControl;
    private Vector3 _MoveDirection = Vector3.zero;
    public float MoveSpeed,JumpThrust,GravityForce,RotateSpeed;
    Vector3 euler;
    private void Awake()
    {
        _currentHP = _maxHP;
        _currentAmmo = 100;
    }
    void Start()
    {
        PlayerRB = GetComponent<Rigidbody>();
        _MovementControl = GetComponent<CharacterController>();
       // Cursor.lockState = CursorLockMode.Locked;
        euler = transform.localEulerAngles;

    }
    // Update is called once per frame
    void Update()  
    {
        Movement();        
        CamRot(); // вращение вышкой с ограничениями
        if (_currentHP <= 0) { Destroy(gameObject); }
    }
    private void CamRot()
    {
        euler.x -= Input.GetAxis("Mouse Y");
        euler.x = Mathf.Clamp(euler.x, -20.0f, 25.0f);

        euler.y += Input.GetAxis("Mouse X");
        euler.y = Mathf.Clamp(euler.y, 150.0f, 220.0f);

        Camera.main.transform.localEulerAngles = euler;
    }
    private void Movement()
    {
        if (_MovementControl.isGrounded)
        {
            _MoveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            _MoveDirection = transform.TransformDirection(_MoveDirection) * -1;
            _MoveDirection *= MoveSpeed;
            if (Input.GetButton("Jump"))
            {
                _MoveDirection.y = JumpThrust;
                _MoveDirection.x /= 2;
                _MoveDirection.z /= 2;
            }
        }
        _MoveDirection.y -= GravityForce * Time.deltaTime * PlayerRB.mass * PlayerRB.mass;
        _MovementControl.Move(_MoveDirection * Time.deltaTime);
        transform.Rotate(0, Input.GetAxis("Horizontal"), 0);
    ///   Input.Ge
    }
    public void TakeDamage(int damage)
    {
        _currentHP -= damage;
    }
    public void GetAmmo(int bullet)
    {
        _currentAmmo += bullet;
    }
    public void RestoreHP(int HP)
    {
        _currentHP = Mathf.Clamp(_currentHP + HP,0,100);
    }

}
