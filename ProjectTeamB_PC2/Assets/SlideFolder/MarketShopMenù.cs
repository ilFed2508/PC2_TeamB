using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarketShopMenù : MonoBehaviour
{
    public GameObject marketPanel;
    public GameObject SlidePanel;
    private SlideManager slideScript;
    

    
    void Start()
    {
        slideScript = GameObject.FindGameObjectWithTag("Player").GetComponent<SlideManager>();
    }

    
    void Update()
    {
        
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        marketPanel.SetActive(false);
        SlidePanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void AddSlide()
    {
        
        marketPanel.SetActive(false);
        slideScript.enabled = true;
        SlidePanel.SetActive(true);
    }
}
