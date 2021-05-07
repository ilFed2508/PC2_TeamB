using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComputerSafeZone : MonoBehaviour
{
    
    private PlayerController EpickUp;
    private SlideManager marketPanel;
    public GameObject HUD;
    public DetectedActDeact HUDReal;
    private GameObject cameraSafe;


    void Update()
    {
        cameraSafe = GameObject.Find("Animation_SafeZone");
        HUD = GameObject.Find("WeaponSlot");
        HUDReal = GameObject.Find("HUD").GetComponent<DetectedActDeact>();
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
            //cameraSafe.SetActive(true);
            other.gameObject.SetActive(false);
            //HUD.SetActive(false);
            //HUDReal.thing.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            //marketPanel.MarketPanel.SetActive(true);
            EpickUp.PickUp.SetActive(false);
            //Time.timeScale = 0f;           
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
