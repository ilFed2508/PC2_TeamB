﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeZone : MonoBehaviour
{
    [Header("Maps")]
    public GameObject mapIn;
    public GameObject mapOut;
    [Header("Safes")]
    public GameObject safeIn;
    public GameObject safeOut;
    [Header("Other Things")]
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
            mapOut.SetActive(true);
            PlayerPrefs.SetInt("Checkpoint", checkpoint);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        mapIn.SetActive(false);
        safeIn.SetActive(false);
        safeOut.SetActive(true);
    }
}
