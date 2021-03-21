using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponPickup : MonoBehaviour
{
    public GameObject WeaponToSpawn;
    private PlayerController playerController;
    public Text UipickupText;

    //Combo LucaDesign
    private ComboManager combo;
    private Animator Camera;
    public float PlayerHpGain;
    //--------------------------------------

    //image "E" pick up - joe
    public GameObject PickUpImage;

    private void Start()
    {
        //Combo LucaDesign
        combo = FindObjectOfType<ComboManager>();
        Camera = GameObject.Find("WeaponSlot").GetComponent<Animator>();
        //-------------------------------------------

        playerController = FindObjectOfType<PlayerController>();
        UipickupText = playerController.UIPickup;
        PickUpImage = playerController.PickUp;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") == true)
        {
            //playerController.UIPickup.gameObject.SetActive(true);
            //image "E" pick up - joe
            playerController.PickUp.gameObject.SetActive(true);
        }
        else
        {
            //image "E" pick up
            playerController.PickUp.gameObject.SetActive(false);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && Input.GetKey(KeyCode.E)|| Input.GetKeyDown(KeyCode.Joystick1Button0))
        { 
            SwitchWeapon();
            //image "E" pick up - joe
            playerController.PickUp.gameObject.SetActive(false);

            //Combo LucaDesign
            combo.livelloCombo = combo.livelloCombo + 1f;
            combo.tempoPerScalare = combo.tempoRestart;
            combo.ComboDamage();
            //-------------------------------------------
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") == true)
        {
            //playerController.UIPickup.gameObject.SetActive(false);
            //image "E" pick up - joe
            playerController.PickUp.gameObject.SetActive(false);
        }
    }

    void SwitchWeapon()
    {
        //da eliminare
        Camera.Play("SwitchWeapon");
        //------------------------------

        //destroy current Weapon
        Destroy(playerController.playerShooting.CurrentRagedWeapon.gameObject);
        //instatiate new weapon at weapon Slot position
        GameObject CurrentNewWeapon = Instantiate(WeaponToSpawn, playerController.WeaponSlot);
        //set current ranged weapon to the one you instatiated
        playerController.playerShooting.CurrentRagedWeapon = CurrentNewWeapon.GetComponent<RangedWeapon>();
        //setup new current ammo
        playerController.playerShooting.CurrentRagedWeapon.SetupCurrentAmmo();
        //deactive pickupUI
        playerController.UIPickup.gameObject.SetActive(false);

        //da modificare
        playerController.playerLife.PlayerCurrentHP += PlayerHpGain;

        //destroy this gameobject
        Destroy(this.gameObject);
        
    }
}
