using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarketShopMenù : MonoBehaviour
{
    public GameObject marketPanel;   
    public GameObject SlideButton;
    public GameObject MedikitButton;
    public GameObject SpeedButton;
    public GameObject SlowerButton;
    public DetectedActDeact HUD;
    public GameObject CrossHair;
    private PowerUpController MyPowerUp;
    private ScoreController MyScore;



    void Start()
    {
        MyScore = FindObjectOfType<ScoreController>();
        MyPowerUp = FindObjectOfType<PowerUpController>();
        HUD = GameObject.Find("HUD").GetComponent<DetectedActDeact>();
    }
    
    public void AddSlide()
    {
        if (PlayerPrefs.GetInt("OnePowerUp") == 0)
        {
            if (MyScore.CostScore > MyPowerUp.SlideCost)
            {
                MyPowerUp.ActiveSlide();
                SlideButton.SetActive(false);
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
            }
        }
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
