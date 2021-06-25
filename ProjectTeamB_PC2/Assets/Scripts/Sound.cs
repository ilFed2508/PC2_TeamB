using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    public string name;            //Nome da dare alla clip

    public AudioClip clip;         //Clip da riprodurre

    [Range(0f, 1f)]
    public float volume;           //Volume della clip

    public bool loop;              //Setto se la clip deve andare in loop

    [HideInInspector]
    public AudioSource source;

    public AudioMixerGroup AudioMixer;
}
