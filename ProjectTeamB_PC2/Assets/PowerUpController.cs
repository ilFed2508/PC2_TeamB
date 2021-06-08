﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PowerUpController : MonoBehaviour
{
    private ScoreController MyScore;
    private SlideManager SlideScript;
    private MedikitManager MyMedikit;
    private SpeedPowerUpManager MySpeed;
    private SlowerHpManager MySlowerPowerUp;
    private KatanaPowerUpManager MyKatana;





    public int SlideCost;
    public int MedikitCost;
    public int SpeedCost;
    public int SlowerCost;
    public int KatanaCost;

    void Start()
    {
        MyScore = FindObjectOfType<ScoreController>();
        SlideScript = FindObjectOfType<SlideManager>();
        MyMedikit = FindObjectOfType<MedikitManager>();
        MySpeed = FindObjectOfType<SpeedPowerUpManager>();
        MySlowerPowerUp = FindObjectOfType<SlowerHpManager>();
        MyKatana = FindObjectOfType<KatanaPowerUpManager>();
    }

    private void Update()
    {

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
        if (PlayerPrefs.GetInt("SlowerHp") == 1)
        {
            MySlowerPowerUp.SlowerHpIsActive = true;
        }
        if (PlayerPrefs.GetInt("Katana") == 1)
        {
            MyKatana.CanUseKatana = true;
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

    public void ActiveSlowerHp()
    {
        PlayerPrefs.SetInt("OnePowerUp", 1);
        MyScore.PurchasePowerUp(SlowerCost);
        PlayerPrefs.SetInt("SlowerHp", 1);
        MySlowerPowerUp.SlowerHpIsActive = true;
        
    }

    public void ActiveKatana()
    {
        PlayerPrefs.SetInt("OnePowerUp", 1);
        MyScore.PurchasePowerUp(KatanaCost);
        PlayerPrefs.SetInt("Katana", 1);
        MyKatana.CanUseKatana = true;

    }




    public void DeactivePowerUp()
    {
        SlideScript.isSliding = false;
        MyMedikit.CanUseMedikit = false;
        MySpeed.Faster = false;
        MySlowerPowerUp.SlowerHpIsActive = false;
        PlayerPrefs.SetInt("OnePowerUp", 0);
        PlayerPrefs.SetInt("Medikit", 0);
        PlayerPrefs.SetInt("Slide", 0);
        PlayerPrefs.SetInt("Speed", 0);
        PlayerPrefs.SetInt("SlowerHp", 0);
        PlayerPrefs.SetInt("Katana", 0);
        if (MyKatana.CanUseKatana == true)
        {
            MyKatana.DestroyKatana();
            MyKatana.CanUseKatana = false;
        }
    }
}
