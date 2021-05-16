using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurrentBehaviour : MonoBehaviour
{
    [SerializeField] private float _minDistance = 50;
    private float _speed = 1;
    private Transform _playerPosition;


    void Start()
    {
        _playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position,_playerPosition.position)< _minDistance)
        {
           Vector3 relative = _playerPosition.position - transform.position;
           Vector3 newDir = Vector3.RotateTowards(transform.forward, relative*-1, _speed * Time.deltaTime, 0f);           
           transform.rotation = Quaternion.LookRotation(newDir);
        }
       
    }

   


}
