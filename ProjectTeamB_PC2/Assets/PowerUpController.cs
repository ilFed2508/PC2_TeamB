using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PowerUpController : MonoBehaviour
{
    private ScoreController MyScore;
    private SlideManager SlideScript;
    private MedikitManager MyMedikit;
    private SpeedPowerUpManager MySpeed;





    public int SlideCost;
    public int MedikitCost;
    public int SpeedCost;

    void Start()
    {
        MyScore = FindObjectOfType<ScoreController>();
    }

    private void Update()
    {

        SlideScript = FindObjectOfType<SlideManager>();
        MyMedikit = FindObjectOfType<MedikitManager>();
        MySpeed = FindObjectOfType<SpeedPowerUpManager>();

        if (PlayerPrefs.GetInt("Slide") == 1)
        {
            SlideScript.isSliding = true;
        }
        if (PlayerPrefs.GetInt("Medikit") == 1)
        {
            MyMedikit.CanUseMedikit = true;
        }
        if (PlayerPrefs.GetInt("Speed") == 1)
        {
            MySpeed.Faster = true;
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
        MyMedikit.NumberOfMedikit = MyMedikit.NumberOfMedikitCopy;
    }

    public void ActiveSuperSpeed()
    {
        PlayerPrefs.SetInt("OnePowerUp", 1);
        MyScore.PurchasePowerUp(SpeedCost);
        PlayerPrefs.SetInt("Speed", 1);
        MySpeed.Faster = true;
    }

    public void DeactivePowerUp()
    {
        SlideScript.isSliding = false;
        MyMedikit.CanUseMedikit = false;
        MySpeed.Faster = true;
        PlayerPrefs.SetInt("OnePowerUp", 0);
        PlayerPrefs.SetInt("Medikit", 0);
        PlayerPrefs.SetInt("Slide", 0);
        PlayerPrefs.SetInt("Speed", 0);
    }
}
