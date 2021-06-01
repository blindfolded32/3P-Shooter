using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumePanel : MonoBehaviour
{
    public Slider VolumeSlider;
    public Toggle MuteToggle;
    public Text VolumeToText;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (MuteToggle.isOn) Mute();
        else VolumeChanger();
    }

    void Mute()
    {
        VolumeSlider.value = 0;
        VolumeToText.text = "0";
    }

    void VolumeChanger()
    {
        VolumeToText.text = VolumeSlider.value.ToString();
    }
}
