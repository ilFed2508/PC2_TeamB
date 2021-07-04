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
    private ComboManager MyTime;
    private PlayerController playerController;

    public GameObject[]Buttons;
    //public GameObject Directional;





    public void Start()
    {        
        playerController = FindObjectOfType<PlayerController>();
        MyTime = FindObjectOfType<ComboManager>();
    }

    private void OnTriggerStay(Collider other)
    {
        //if (other.CompareTag("Player"))
        //{
        //    MyTime.ComboTime = 0f;
        //}
        MyTime.ComboTime = 0f;
        if (other.CompareTag("Player") && playerController.SafeZoneReached != checkpoint)
        {
            playerController.SafeZoneReached = checkpoint;
        }
        if (other.CompareTag("Player") && playerController.playerLife.PlayerCurrentHP < playerController.playerLife.PlayerStartingHP)
        {
            playerController.playerLife.PlayerCurrentHP -= recoverdLife * Time.deltaTime;
            MyTime.ComboTime = 0f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && playerController.SafeZoneReached != checkpoint)
        {
            //Directional.SetActive(true);
            mapOut.SetActive(true);
            mapIn.SetActive(false);
            playerController.SafeZoneReached = checkpoint;
            playerController.playerScore.AddValueScore((int)playerController.playerLife.PlayerHPscore * ((checkpoint - 1) * playerController.playerScore.GetActionValue(ScoreAction.EndLevelLifeGain)));
            playerController.playerScore.AddTotalScore(playerController.playerScore.GetCurrentScore());
            PlayerPrefs.SetInt("Checkpoint", checkpoint);
            MyTime.ComboTime = 0f;
            
        }
        else if(other.CompareTag("Player") && playerController.SafeZoneReached == checkpoint)
        {
            //Directional.SetActive(true);
            mapOut.SetActive(true);
            mapIn.SetActive(false);
            PlayerPrefs.SetInt("Checkpoint", checkpoint);
            MyTime.ComboTime = 0f;
        }                      
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerController.playerScore.SetScore(0);
            MyTime.ComboTime = 1f;
        }
    }
}
