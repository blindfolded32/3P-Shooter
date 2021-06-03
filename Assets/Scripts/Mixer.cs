using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Mixer : MonoBehaviour
{
    private AudioSource audio;
    public AudioMixer masterMixer;
    // Start is called before the first frame update
    private void Awake()
    {
        audio = GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);
    }

    public void  RegulateVolume(float value)
    {
        if (value == 0) masterMixer.SetFloat("MasterVolume", (value-80));
        masterMixer.SetFloat("MasterVolume", (value - 80));
        //audio.volume = value/100;
        //  print(audio.volume);
    }
        

}
