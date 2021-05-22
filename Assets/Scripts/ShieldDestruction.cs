using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldDestruction : MonoBehaviour
{
    private int _shieldHP = 30;
    private int _bossShieldHp = 50;
    private int _currentHP;

    void Awake()
    {
        if (gameObject.tag == "BossShield")
        {
            _currentHP = _bossShieldHp;
        }
        else _currentHP = _shieldHP;
        }
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Bullet")
        {
            if (gameObject.tag == "BossShield") _currentHP = TakeDamage(5, _currentHP);
             
            else  _currentHP = TakeDamage(5, _currentHP);
        }
    }

    int TakeDamage(int damage, int currentHP)
    {
        currentHP -= damage;
      //  print(gameObject.tag +" "+ currentHP);
        if (currentHP <= 0) Destroy(gameObject);
        return currentHP;
    }

}
