using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComputerSafeZone : MonoBehaviour
{
    
    private PlayerController EpickUp;
    private SlideManager marketPanel;
    public GameObject HUD, cameraSafe, powerUP, Emote, Particle;
    public DetectedActDeact HUDReal;
    private PorcaTroiaProviamo MyCameraMovemant;
    private void Start()
    {
        MyCameraMovemant = FindObjectOfType<PorcaTroiaProviamo>();
    }
    void Update()
    {      
        EpickUp = FindObjectOfType<PlayerController>();       
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
            Emote.SetActive(false);
            cameraSafe.SetActive(true);
            powerUP.SetActive(true);
            Particle.SetActive(false);
            AudioManager.instance.Play("PCInteract");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;         
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
