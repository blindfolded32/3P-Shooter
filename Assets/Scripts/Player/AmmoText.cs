using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoText : MonoBehaviour
{
    public Text ammoText;

    public void PrintAmmo(int BulletsIn, int FullAmmo)
    {
        ammoText.text = BulletsIn.ToString() + "/" + FullAmmo.ToString(); 
        
    }
}
