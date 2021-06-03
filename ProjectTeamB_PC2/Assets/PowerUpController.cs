using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    private ScoreController MyScore;
    private SlideManager SlideScript;
    private MarketShopMenù MyMarket;

    public int SlideCost;

    void Start()
    {
        MyMarket = FindObjectOfType<MarketShopMenù>();
        SlideScript = FindObjectOfType<SlideManager>();
        MyScore = FindObjectOfType<ScoreController>();
    }


    public void ActiveSlide()
    {
        if(MyScore.CostScore > SlideCost)
        {
            MyScore.PurchasePowerUp(SlideCost);
            SlideScript.isSliding = true;
            MyMarket.SlideButton.SetActive(false);
        }
        
    }
    public void DeactivePowerUp()
    {
            
        SlideScript.isSliding = false;
        MyMarket.SlideButton.SetActive(true);

    }


}
