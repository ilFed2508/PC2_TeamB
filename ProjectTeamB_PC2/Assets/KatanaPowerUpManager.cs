using System.Collections;
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
                if (Input.GetMouseButtonDown(1) || Input.GetButton("Xbox_LB"))
                {
                    SwitchKatanaWeapon();
                }
            }

        }

       if(CanUseKatana == false)
       {          
           IconIsActive = false;
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
        //deactive pickupUI
        //playerController.UIPickup.gameObject.SetActive(false);
        //guadagna punti per lo score
        //playerController.playerScore.AddScore(1);
        //da modificare
        //playerController.playerLife.PlayerCurrentHP += PlayerHpGain;
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
        //deactive pickupUI
        //playerController.UIPickup.gameObject.SetActive(false);
        //guadagna punti per lo score
        //playerController.playerScore.AddScore(1);
        //da modificare
        //playerController.playerLife.PlayerCurrentHP += PlayerHpGain;
    }
}
