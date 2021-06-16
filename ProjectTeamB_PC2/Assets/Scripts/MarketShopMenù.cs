using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarketShopMenù : MonoBehaviour
{
    public GameObject marketPanel;   
    public GameObject SlideButton, SlideOFF;
    public GameObject MedikitButton, MedkitOFF;
    public GameObject SpeedButton, SpeedOFF;
    public GameObject SlowerButton, SlowerOFF;
    public GameObject KatanaButton, KatanaOFF;
    public DetectedActDeact HUD;
    public GameObject CrossHair;

    private PowerUpController MyPowerUp;
    private ScoreController MyScore;

    public GameObject[] BlockButtons;

    void Start()
    {
        MyScore = FindObjectOfType<ScoreController>();
        MyPowerUp = FindObjectOfType<PowerUpController>();
        HUD = GameObject.Find("HUD").GetComponent<DetectedActDeact>();
    }

    public void Update()
    {
        ActiveButtonsOFF();
    }

    public void AddSlide()
    {
        if (PlayerPrefs.GetInt("OnePowerUp") == 0)
        {
            if (MyScore.CostScore > MyPowerUp.SlideCost)
            {
                MyPowerUp.ActiveSlide();
                SlideButton.SetActive(false);
                SlideOFF.SetActive(true);
            }
        }           
    }

    public void AddMedikit()
    {
        if (PlayerPrefs.GetInt("OnePowerUp") == 0)
        {
            if (MyScore.CostScore > MyPowerUp.MedikitCost)
            {
                MyPowerUp.ActiveMedikit();
                MedikitButton.SetActive(false);
                MedkitOFF.SetActive(true);
            }
        }
    }

    public void AddSpeed()
    {
        if (PlayerPrefs.GetInt("OnePowerUp") == 0)
        {
            if (MyScore.CostScore > MyPowerUp.SpeedCost)
            {
                MyPowerUp.ActiveSuperSpeed();
                SpeedButton.SetActive(false);
                SpeedOFF.SetActive(true);
            }
        }
    }

    public void AddSlowerHp()
    {
        if (PlayerPrefs.GetInt("OnePowerUp") == 0)
        {
            if (MyScore.CostScore > MyPowerUp.SlowerCost)
            {
                MyPowerUp.ActiveSlowerHp();
                SlowerButton.SetActive(false);
                SlowerOFF.SetActive(true);
            }
        }
    }

    public void AddKatana()
    {
        if (PlayerPrefs.GetInt("OnePowerUp") == 0)
        {
            if (MyScore.CostScore > MyPowerUp.KatanaCost)
            {
                MyPowerUp.ActiveKatana();
                KatanaButton.SetActive(false);
                KatanaOFF.SetActive(true);
            }
        }
    }

    public void ActiveButtonsOFF()
    {
        if (PlayerPrefs.GetInt("Slide") == 1 || PlayerPrefs.GetInt("Medikit") == 1 || PlayerPrefs.GetInt("Speed") == 1 || PlayerPrefs.GetInt("SlowerHp") == 1 || PlayerPrefs.GetInt("Katana") == 1)
        {
            for (int i = 0; i < BlockButtons.Length; i++)
            {
                BlockButtons[i].SetActive(false);
            }
            //SlideButton.SetActive(false);
            //SlideOFF.SetActive(true);
        }

        //if (PlayerPrefs.GetInt("Medikit") == 1)
        //{
        //    MedikitButton.SetActive(false);
        //    MedkitOFF.SetActive(true);
        //}
        //
        //if (PlayerPrefs.GetInt("Speed") == 1)
        //{
        //    SpeedButton.SetActive(false);
        //    SpeedOFF.SetActive(true);
        //}
        //
        //if (PlayerPrefs.GetInt("SlowerHp") == 1)
        //{
        //    SlowerButton.SetActive(false);
        //    SlowerOFF.SetActive(true);
        //}
        //
        //if (PlayerPrefs.GetInt("Katana") == 1)
        //{
        //    KatanaButton.SetActive(false);
        //    KatanaOFF.SetActive(true);
        //}
    }

    public void Exit()
    {
        CrossHair.SetActive(true);
        HUD.thing.SetActive(true);
        marketPanel.SetActive(false);
        Time.timeScale = 1;               
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
