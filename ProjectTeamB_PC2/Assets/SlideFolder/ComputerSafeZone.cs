using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComputerSafeZone : MonoBehaviour
{
    
    private PlayerController EpickUp;
    private SlideManager marketPanel;
    // Start is called before the first frame update
    void Update()
    {
       
        EpickUp = FindObjectOfType<PlayerController>();
        marketPanel = FindObjectOfType<SlideManager>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EpickUp.PickUp.SetActive(true);

        }
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {          
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
