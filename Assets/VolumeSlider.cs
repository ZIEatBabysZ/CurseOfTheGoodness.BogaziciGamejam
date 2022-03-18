using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeSlider : MonoBehaviour
{
    public AudioMixer aud;
    public Slider vslider;
    public float volumeValue;
    void Start()
    {
        vslider = GetComponent<Slider>();
        aud.GetFloat("volume",out volumeValue);
        vslider.value = volumeValue;
    }

    
}
