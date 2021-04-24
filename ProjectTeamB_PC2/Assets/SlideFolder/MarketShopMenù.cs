﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarketShopMenù : MonoBehaviour
{
    public GameObject marketPanel;   
    private SlideManager slideScript;
    public GameObject SlideButton;
    public GameObject HUD, CrossHair;



    void Start()
    {
        slideScript = FindObjectOfType<SlideManager>();
    }

    
    void Update()
    {
        
    }
    
    public void AddSlide()
    {
        slideScript.isSliding = true;
        SlideButton.SetActive(false);
    }
    public void Exit()
    {
        CrossHair.SetActive(true);
        HUD.SetActive(true);
        Time.timeScale = 1;        
        marketPanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
