using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponentInParent<Animator>();
    }

   
    
}
