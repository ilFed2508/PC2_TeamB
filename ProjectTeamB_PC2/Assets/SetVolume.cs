using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SetVolume : MonoBehaviour
{
    public AudioMixer Mixeer;

    public string MixerName;
    
    public void SetLevel(float slidervalue)
    {
        Mixeer.SetFloat(MixerName, Mathf.Log10(slidervalue) * 20);
    }
}

