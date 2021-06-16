using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
    public TextMeshProUGUI MyCurrentScore;

    private PowerUpController MyPowerUp;
    private ScoreController MyScore;

    public GameObject[] BlockButtons,OFFBlockButtons;

    void Start()
    {
        MyScore = FindObjectOfType<ScoreController>();
        MyPowerUp = FindObjectOfType<PowerUpController>();
        HUD = GameObject.Find("HUD").GetComponent<DetectedActDeact>();
        ActiveButtonsOFF();
    }

    public void Update()
    {
        MyCurrentScore.text = MyScore.CostScore.ToString();
    }

    public void AddSlide()
    {
        if (PlayerPrefs.GetInt("OnePowerUp") == 0)
        {
            if (MyScore.CostScore > MyPowerUp.SlideCost)
            {
                MyPowerUp.ActiveSlide();
                ActiveButtonsOFF();
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
                ActiveButtonsOFF();
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
                ActiveButtonsOFF();
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
                ActiveButtonsOFF();
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
                ActiveButtonsOFF();
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
            for (int i = 0; i < OFFBlockButtons.Length; i++)
            {
                OFFBlockButtons[i].SetActive(true);
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
