using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PowerUpController : MonoBehaviour
{
    private ScoreController MyScore;
    private SlideManager SlideScript;
    
    


    public int SlideCost;

    void Start()
    {

        SlideScript = FindObjectOfType<SlideManager>();
        MyScore = FindObjectOfType<ScoreController>();
    }


    public void ActiveSlide()
    {
        MyScore.PurchasePowerUp(SlideCost);
        SlideScript.isSliding = true;     
    }
    public void DeactivePowerUp()
    {           
        SlideScript.isSliding = false;      
    }
}
