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
        SlideScript = FindObjectOfType<SlideManager>();
        MyMedikit = FindObjectOfType<MedikitManager>();
        MyScore = FindObjectOfType<ScoreController>();
    }


    public void ActiveSlide()
    {
        MyScore.PurchasePowerUp(SlideCost);
        SlideScript.isSliding = true;     
    }

    public void ActiveMedikit()
    {
        MyScore.PurchasePowerUp(MedikitCost);
        MyMedikit.CanUseMedikit = true;
    }

    public void DeactivePowerUp()
    {           
        SlideScript.isSliding = false;
        MyMedikit.CanUseMedikit = false;
    }
}
