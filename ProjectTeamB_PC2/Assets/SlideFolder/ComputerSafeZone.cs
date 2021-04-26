using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComputerSafeZone : MonoBehaviour
{
    
    private PlayerController EpickUp;
    private SlideManager marketPanel;
    public GameObject HUD;
    void Update()
    {
        HUD = GameObject.Find("WeaponSlot");
        EpickUp = FindObjectOfType<PlayerController>();
        marketPanel = FindObjectOfType<SlideManager>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EpickUp.PickUp.SetActive(true);

        }
        if (other.CompareTag("Player") && Input.GetKey(KeyCode.E))
        {
            HUD.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            marketPanel.MarketPanel.SetActive(true);
            EpickUp.PickUp.SetActive(false);
            Time.timeScale = 0f;           
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EpickUp.PickUp.SetActive(false);

        }
    }
}
