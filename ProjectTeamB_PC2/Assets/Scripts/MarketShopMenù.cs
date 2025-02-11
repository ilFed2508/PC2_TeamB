﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarketShopMenù : MonoBehaviour
{
    public GameObject marketPanel;   
    private SlideManager slideScript;
    public GameObject SlideButton;
    public DetectedActDeact HUD;
    public GameObject CrossHair;



    void Start()
    {
        slideScript = FindObjectOfType<SlideManager>();
        HUD = GameObject.Find("HUD").GetComponent<DetectedActDeact>();
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
        HUD.thing.SetActive(true);
        Time.timeScale = 1;        
        marketPanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
