using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PowerUpController : MonoBehaviour
{
    private ScoreController MyScore;
    private SlideManager SlideScript;
    private MedikitManager MyMedikit;





    public int SlideCost;
    public int MedikitCost;

    void Start()
    {
        MyScore = FindObjectOfType<ScoreController>();
    }

    private void Update()
    {

        SlideScript = FindObjectOfType<SlideManager>();
        MyMedikit = FindObjectOfType<MedikitManager>();

        if (PlayerPrefs.GetInt("Slide") == 1)
        {
            SlideScript.isSliding = true;
        }
        if (PlayerPrefs.GetInt("Medikit") == 1)
        {
            MyMedikit.CanUseMedikit = true;
        }
    }


    public void ActiveSlide()
    {
        PlayerPrefs.SetInt("OnePowerUp", 1);
        MyScore.PurchasePowerUp(SlideCost);
        PlayerPrefs.SetInt("Slide", 1);
        SlideScript.isSliding = true;     
    }

    public void ActiveMedikit()
    {
        PlayerPrefs.SetInt("OnePowerUp", 1);
        MyScore.PurchasePowerUp(MedikitCost);
        PlayerPrefs.SetInt("Medikit", 1);
        MyMedikit.CanUseMedikit = true;
    }

    public void DeactivePowerUp()
    {
        SlideScript.isSliding = false;
        MyMedikit.CanUseMedikit = false;
        PlayerPrefs.SetInt("OnePowerUp", 0);
        PlayerPrefs.SetInt("Medikit", 0);
        PlayerPrefs.SetInt("Slide", 0);
    }
}
