using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCall : MonoBehaviour
{
    public GameObject Menu;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().Stop(true);
            Menu.SetActive(true);
            
            var enemies = GameObject.FindGameObjectsWithTag("RangeEnemy");
            foreach (var enemy in enemies) enemy.GetComponent<PatrolMove>().Stop(true);
        }
    }
}
