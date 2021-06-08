﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KatanaPowerUpManager : MonoBehaviour
{
    public GameObject WeaponToSpawn;
    public GameObject SecondWeaponToSpawn;

    private PlayerController playerController;
    private Animator Camera;

    public bool CanUseKatana;
    private bool IconIsActive;

    public GameObject KatanaIcon;


    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        Camera = GameObject.Find("WeaponSlot").GetComponent<Animator>();
        CanUseKatana = false;
        IconIsActive = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(CanUseKatana == true)
        {
            if (IconIsActive == true)
            {
                KatanaIcon.SetActive(true);
                if (Input.GetMouseButtonDown(1) || Input.GetButton("Xbox_LB"))
                {
                    SwitchKatanaWeapon();
                    KatanaIcon.SetActive(false);
                    IconIsActive = false;
                }
            }

        }

       if(CanUseKatana == false)
       {
            KatanaIcon.SetActive(false);
            IconIsActive = true;
       }
    }


    public void SwitchKatanaWeapon()
    {
        //da eliminare
        Camera.Play("SwitchWeapon");
        //------------------------------
        //AudioManager.instance.Play(Suono);
        //destroy current Weapon
        Destroy(playerController.playerShooting.CurrentRagedWeapon.gameObject);
        //instatiate new weapon at weapon Slot position
        GameObject CurrentNewWeapon = Instantiate(WeaponToSpawn, playerController.WeaponSlot);
        //set current ranged weapon to the one you instatiated
        playerController.playerShooting.CurrentRagedWeapon = CurrentNewWeapon.GetComponent<RangedWeapon>();
        //setup new current ammo
        playerController.playerShooting.CurrentRagedWeapon.SetupCurrentAmmo();
        //update digetic ammo UI
        playerController.playerShooting.DiegeticAmmo = playerController.playerShooting.CurrentRagedWeapon.GetComponentInChildren<TextMeshProUGUI>();

    }
    public void DestroyKatana()
    {
        //da eliminare
        Camera.Play("SwitchWeapon");
        //------------------------------
        //AudioManager.instance.Play(Suono);
        //destroy current Weapon
        Destroy(playerController.playerShooting.CurrentRagedWeapon.gameObject);
        //instatiate new weapon at weapon Slot position
        GameObject CurrentNewWeapon = Instantiate(SecondWeaponToSpawn, playerController.WeaponSlot);
        //set current ranged weapon to the one you instatiated
        playerController.playerShooting.CurrentRagedWeapon = CurrentNewWeapon.GetComponent<RangedWeapon>();
        //setup new current ammo
        playerController.playerShooting.CurrentRagedWeapon.SetupCurrentAmmo();
        //update digetic ammo UI
        playerController.playerShooting.DiegeticAmmo = playerController.playerShooting.CurrentRagedWeapon.GetComponentInChildren<TextMeshProUGUI>();
    }
}
