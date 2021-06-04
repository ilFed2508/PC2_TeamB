using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PowerUpController : MonoBehaviour
{
    private ScoreController MyScore;
    private SlideManager SlideScript;
    private SafeZone MyButtons;
    


    public int SlideCost;

    void Start()
    {
        
        MyButtons = FindObjectOfType<SafeZone>();
        SlideScript = FindObjectOfType<SlideManager>();
        MyScore = FindObjectOfType<ScoreController>();
    }


    public void ActiveSlide()
    {
        if(MyScore.CostScore > SlideCost)
        {          
            MyScore.PurchasePowerUp(SlideCost);
            MyButtons.SlideButton.SetActive(false);
            SlideScript.isSliding = true;           
        }
        
    }
    public void DeactivePowerUp()
    {           
        SlideScript.isSliding = false;
        MyButtons.SlideButton.SetActive(true);
        //MyMarker.SlideButton.SetActive(true);
    }

}
