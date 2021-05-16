using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMakeActive : MonoBehaviour
{
   public void OpenDoor()
    {
        gameObject.SetActive(false);
    }
    public void CloseDoor()
    {
        gameObject.SetActive(true);
    }
}
