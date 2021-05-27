using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotatation : MonoBehaviour
{
    public Camera cam;
    public Transform target;
    public float speedX = 360f;
    public float speedy = 240f;
    public float minDistance = 1.5f;
    public float hideDistance = 2f;
    private Vector3 _localPosition;
    private float _currentYRotation;
   

    private Vector3 _position
    {
        get { return transform.position; }
        set { transform.position = value; }
    }

    void Start()
    {
        _localPosition = target.InverseTransformPoint(_position);
    }

    void LateUpdate()
    {
        _position = target.TransformPoint(_localPosition);
        CameraRotation();
       
        _localPosition = target.InverseTransformPoint(_position);
    }

    void CameraRotation()
    {
        if (Input.GetAxis("Mouse Y") != 0)
        {
            var tmp = Mathf.Clamp(_currentYRotation + Input.GetAxis("Mouse Y") * speedy * Time.deltaTime, -40, 90);
            if (tmp != _currentYRotation)
            {
                var rot = tmp - _currentYRotation;
                transform.RotateAround(target.position, transform.right *-1, rot);
                _currentYRotation = tmp;
            }
        }
        if (Input.GetAxis("Mouse X") != 0)
        {
            transform.RotateAround(target.position, Vector3.up, Input.GetAxis("Mouse X") * speedX * Time.deltaTime);
        }
        transform.LookAt(target);
    }

}