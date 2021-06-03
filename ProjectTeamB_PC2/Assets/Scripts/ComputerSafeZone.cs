using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComputerSafeZone : MonoBehaviour
{
    
    private PlayerController EpickUp;
    private SlideManager marketPanel;
    public GameObject HUD, cameraSafe, powerUP;
    public DetectedActDeact HUDReal;
    private PorcaTroiaProviamo MyCameraMovemant;
    private void Start()
    {
        MyCameraMovemant = FindObjectOfType<PorcaTroiaProviamo>();
    }
    void Update()
    {
        
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
        if (other.CompareTag("Player") && (Input.GetKey(KeyCode.E) || Input.GetButton("Xbox_X")))
        {

            MyCameraMovemant.Player.SetActive(false);
            cameraSafe.SetActive(true);
            powerUP.SetActive(true);            
            //leaderBoard.SetActive(true);
            //HUD.SetActive(false);
            //HUDReal.thing.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            //marketPanel.MarketPanel.SetActive(true);
            //EpickUp.PickUp.SetActive(false);
            //Time.timeScale = 0f;           
        }

        else

        {
            //powerUP.SetActive(false);
            //leaderBoard.SetActive(false);
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
