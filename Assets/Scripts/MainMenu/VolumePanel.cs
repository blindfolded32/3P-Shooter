using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumePanel : MonoBehaviour
{
    public Slider VolumeSlider;
    public Toggle MuteToggle;
    public Text VolumeToText;
    public AudioMixer mixer;
    // Start is called before the first frame update
    void Start()
    {
        mixer.GetFloat("MasterVolume", out float val);
        VolumeSlider.value =  val+ 80;
        VolumeToText.text = VolumeSlider.value.ToString();
        DontDestroyOnLoad(mixer);
        
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
        mixer.SetFloat("MasterVolume", (-80));
    }

    void VolumeChanger()
    {
        VolumeToText.text = VolumeSlider.value.ToString();
       mixer.SetFloat("MasterVolume", (VolumeSlider.value - 80));
    }
}
