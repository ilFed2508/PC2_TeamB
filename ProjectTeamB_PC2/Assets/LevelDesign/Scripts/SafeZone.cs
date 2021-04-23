using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeZone : MonoBehaviour
{
    public GameObject mapIn, mapOut;
    public float recoverdLife;
    public int checkpoint;

    private PlayerLifeSystem playerLife;

    public void Start()
    {
        playerLife = FindObjectOfType<PlayerLifeSystem>();
    }

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
