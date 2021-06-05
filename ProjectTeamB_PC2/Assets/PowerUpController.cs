using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PowerUpController : MonoBehaviour
{
    private ScoreController MyScore;
    private SlideManager SlideScript;
    private MedikitManager MyMedikit;
    public bool SlidePurchased;
    public bool MedikitPurchased;





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
        MyScore.PurchasePowerUp(SlideCost);
        PlayerPrefs.SetInt("Slide", 1);
        SlidePurchased = true;
        SlideScript.isSliding = true;     
    }

    public void ActiveMedikit()
    {
        MyScore.PurchasePowerUp(MedikitCost);
        PlayerPrefs.SetInt("Medikit", 1);
        MyMedikit.CanUseMedikit = true;
    }

    public void DeactivePowerUp()
    {
        PlayerPrefs.SetInt("Medikit", 0);
        PlayerPrefs.SetInt("Slide", 0);
        SlideScript.isSliding = false;
        MyMedikit.CanUseMedikit = false;
    }
}
