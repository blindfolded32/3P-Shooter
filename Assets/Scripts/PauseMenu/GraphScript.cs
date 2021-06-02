using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GraphScript : MonoBehaviour
{
    public Toggle ScreenToggle;
    // Start is called before the first frame update
    void Start()
    {
         ScreenToggle.isOn =  Screen.fullScreen;
      
    }

    private void Update()
    {
         ScreenMode();
    }

    void ScreenMode()
    {
        Screen.fullScreen = ScreenToggle.isOn;
       
    }
}
