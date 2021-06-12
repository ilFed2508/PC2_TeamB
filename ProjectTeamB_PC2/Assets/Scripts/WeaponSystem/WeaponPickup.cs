using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeaponPickup : MonoBehaviour
{
    public GameObject WeaponToSpawn;
    private PlayerController playerController;
    private KatanaPowerUpManager MyKatana;
    public Text UipickupText;

    //Combo LucaDesign
    private ComboManager combo;
    private Animator Camera;
    public float PlayerHpGain;
    public string Suono;
    //--------------------------------------

    //image "E" pick up - joe
    public GameObject PickUpImage;

    private void Start()
    {
        //Combo LucaDesign
        combo = FindObjectOfType<ComboManager>();
        Camera = GameObject.Find("WeaponSlot").GetComponent<Animator>();
        MyKatana = FindObjectOfType<KatanaPowerUpManager>();
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
        if (other.CompareTag("Player") == true)
        {
            //playerController.UIPickup.gameObject.SetActive(true);
            //image "E" pick up - joe
            playerController.PickUp.gameObject.SetActive(true);
        }
        if (MyKatana.CanSwitchKatana == false && other.gameObject.CompareTag("Player") && Input.GetKey(KeyCode.E)|| Input.GetButtonDown("Xbox_X"))
        { 
            SwitchWeapon();
            //image "E" pick up - joe
            playerController.PickUp.gameObject.SetActive(false);

            //Combo LucaDesign
            combo.livelloCombo = combo.livelloCombo + 1;

            if(combo.livelloCombo > 0)
            {
                if(combo.livelloCombo > 1)
                {
                  combo.Sprite[combo.i - 1].SetActive(false);
                }
                
                combo.Sprite[combo.i].SetActive(true);
            }
            combo.tempoPerScalare = combo.tempoRestart;
            combo.ComboDamage();
            //-------------------------------------------
        }
        if (MyKatana.CanSwitchKatana == true && other.gameObject.CompareTag("Player") && Input.GetKey(KeyCode.E) || Input.GetButtonDown("Xbox_X"))
        {
            MyKatana.SwitchKatanaWeapon();

            //destroy this gameobject
            Destroy(this.gameObject);

            playerController.PickUp.gameObject.SetActive(false);

            //Combo LucaDesign
            combo.livelloCombo = combo.livelloCombo + 1;

            if (combo.livelloCombo > 0)
            {
                if (combo.livelloCombo > 1)
                {
                    combo.Sprite[combo.i - 1].SetActive(false);
                }

                combo.Sprite[combo.i].SetActive(true);
            }
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
        AudioManager.instance.Play(Suono);
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
        playerController.UIPickup.gameObject.SetActive(false);
        //guadagna punti per lo score
        playerController.playerScore.AddScore(1);
        //da modificare
        playerController.playerLife.PlayerCurrentHP += PlayerHpGain;

        //destroy this gameobject
        Destroy(this.gameObject);
        
    }
}
