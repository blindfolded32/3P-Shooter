using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldDestruction : MonoBehaviour
{
    private int _shieldHP = 30;
   // private int _bossShieldHp = 30;
    private int _currentHP;
    private ParticleSystem _particle;

    void Awake()
    {
        _particle = GetComponent<ParticleSystem>();
         _currentHP = _shieldHP;
        }
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Bullet"))
        {
           _currentHP = TakeDamage(5, _currentHP);
        }
    }

    int TakeDamage(int damage, int currentHP)
    {
        _particle.Play();
        currentHP -= damage;
      //  print(gameObject.tag +" "+ currentHP);
        if (currentHP <= 0) Destroy(gameObject);
        return currentHP;
    }

}
