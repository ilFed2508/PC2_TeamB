using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeZone : MonoBehaviour
{
    [Header("Maps")]
    public GameObject mapIn;
    public GameObject mapIn2;
    public GameObject mapOut;
    [Header("Other Things")]
    public float recoverdLife;
    public int checkpoint;

    private PlayerController playerController;

    public GameObject[]Buttons;
    public GameObject Directional;





    public void Start()
    {        
        playerController = FindObjectOfType<PlayerController>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && playerController.SafeZoneReached != checkpoint)
        {
            playerController.SafeZoneReached = checkpoint;
        }
        if (other.CompareTag("Player") && playerController.playerLife.PlayerCurrentHP < playerController.playerLife.PlayerStartingHP)
        {
            playerController.playerLife.PlayerCurrentHP -= recoverdLife * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && playerController.SafeZoneReached != checkpoint)
        {
            Directional.SetActive(true);
            mapOut.SetActive(true);
            mapIn.SetActive(false);
            playerController.SafeZoneReached = checkpoint;
            playerController.playerScore.AddValueScore((int)playerController.playerLife.PlayerCurrentHP * ((checkpoint - 1) * playerController.playerScore.GetActionValue(ScoreAction.EndLevelLifeGain)));
            playerController.playerScore.AddTotalScore(playerController.playerScore.GetCurrentScore());
            PlayerPrefs.SetInt("Checkpoint", checkpoint);
            
        }
        else if(other.CompareTag("Player") && playerController.SafeZoneReached == checkpoint)
        {
            Directional.SetActive(true);
            mapOut.SetActive(true);
            mapIn.SetActive(false);
            PlayerPrefs.SetInt("Checkpoint", checkpoint);            
        }                      
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerController.playerScore.SetScore(0);
        }
    }
}
