using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMenùMain : MonoBehaviour
{
    public GameObject VideoLvl2, VideoLvl3, VideoLvl4, Noiselv2, Noiselv3, Noiselv4;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        PlayerPrefs.SetInt("OnePowerUp", 0);
        PlayerPrefs.SetInt("Slide", 0);
        PlayerPrefs.SetInt("Medikit", 0);
        PlayerPrefs.SetInt("Speed", 0);
        PlayerPrefs.SetInt("SlowerHp", 0);
        PlayerPrefs.SetInt("Katana", 0);


        if (PlayerPrefs.GetInt("UNO") == 1)
        {
            VideoLvl2.SetActive(true);
            Noiselv2.SetActive(false);
        }
        if (PlayerPrefs.GetInt("DUE") == 1)
        {
            VideoLvl3.SetActive(true);
            Noiselv3.SetActive(false);
        }
        if (PlayerPrefs.GetInt("TRE") == 1)
        {
            VideoLvl4.SetActive(true);
            Noiselv4.SetActive(false);
        }

    }
}
