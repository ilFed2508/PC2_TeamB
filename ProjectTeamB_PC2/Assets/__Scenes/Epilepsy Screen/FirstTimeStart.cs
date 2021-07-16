using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstTimeStart : MonoBehaviour
{
    static int NofStarts;

    private void Awake()
    {
        NofStarts = PlayerPrefs.GetInt("BootsUp");
        if(NofStarts==0)
        {
            Screen.SetResolution(1920, 1080, Screen.fullScreen);
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
