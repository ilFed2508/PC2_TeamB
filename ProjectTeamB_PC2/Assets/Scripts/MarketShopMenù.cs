using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarketShopMenù : MonoBehaviour
{
    public GameObject marketPanel;   
    public GameObject SlideButton;
    public DetectedActDeact HUD;
    public GameObject CrossHair;
    private PowerUpController MyPowerUp;



    void Start()
    {
        MyPowerUp = FindObjectOfType<PowerUpController>();
        HUD = GameObject.Find("HUD").GetComponent<DetectedActDeact>();
    }
    
    public void AddSlide()
    {
        MyPowerUp.ActiveSlide();             
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
