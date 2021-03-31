﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleePercentuale : MonoBehaviour
{
    
    private PlayerLifeSystem playerLifeScript;
    public float percentuale;
    private float percentualeDaSottrarre;
    private PlayerController playerController;

    private CharacterController Player;
    public float mass = 50; 
    Vector3 impact = Vector3.zero;

    private Animator WeaponSlot;



    public void Start()
    {
        WeaponSlot = GameObject.Find("WeaponSlot").GetComponent<Animator>();
        Player = GameObject.Find("Player").GetComponent<CharacterController>();
        playerController = FindObjectOfType<PlayerController>();
        playerLifeScript = GameObject.Find("Player").GetComponent<PlayerLifeSystem>();
    }
    public void Update()
    {
        
        percentualeDaSottrarre = playerLifeScript.PlayerCurrentHP * percentuale / 100f;
        impact = Vector3.Lerp(impact, transform.forward, 5 * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.R))
        {
            Player.Move(impact * mass * Time.deltaTime);
            WeaponSlot.Play("Melee-WeaponSlot");
            playerController.Melee.gameObject.SetActive(true);
            StartCoroutine(LateCall());
            playerLifeScript.PlayerCurrentHP = playerLifeScript.PlayerCurrentHP -  percentualeDaSottrarre;           
        }
        
    }

    private IEnumerator LateCall()
    {
        yield return new WaitForSeconds(1f);
        playerController.Melee.gameObject.SetActive(false);
    }

    


}
