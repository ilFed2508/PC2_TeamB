using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeZone : MonoBehaviour
{
    public GameObject mapIn, mapOut;
    public float recoverdLife;
    public int checkpoint;

    public PlayerLifeSystem playerLife;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && playerLife.PlayerCurrentHP < playerLife.PlayerStartingHP)
        {
            playerLife.PlayerCurrentHP += recoverdLife * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            mapIn.SetActive(false);
            mapOut.SetActive(true);
            PlayerPrefs.SetInt("Checkpoint", checkpoint);
        }
    }
}
