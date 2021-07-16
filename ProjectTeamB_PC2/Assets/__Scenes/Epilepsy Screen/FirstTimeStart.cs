using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class FirstTimeStart : MonoBehaviour
{
    static int NofStarts;

    public AudioMixer SFX, General;

    private void Awake()
    {
        NofStarts = PlayerPrefs.GetInt("BootsUp");
        if(NofStarts==0)
        {
            Screen.SetResolution(1920, 1080, Screen.fullScreen);
            PlayerPrefs.SetInt("Resolution", 1);
            PlayerPrefs.SetFloat("GeneraL", 0.5f);
            PlayerPrefs.SetFloat("SFX", 0.5f);
            SFX.SetFloat("Sound Effects", Mathf.Log10(PlayerPrefs.GetFloat("SFX"))*20);
            General.SetFloat("Menù", Mathf.Log10(PlayerPrefs.GetFloat("GeneraL"))*20);
        }
        NofStarts++;
        PlayerPrefs.SetInt("BootsUp", NofStarts);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
