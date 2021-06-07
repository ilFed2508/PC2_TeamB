using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMenùMain : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        PlayerPrefs.SetInt("OnePowerUp", 0);
        PlayerPrefs.SetInt("Slide", 0);
        PlayerPrefs.SetInt("Medikit", 0);
        PlayerPrefs.SetInt("Speed", 0);
        PlayerPrefs.SetInt("SlowerHp", 0);

    }
}
