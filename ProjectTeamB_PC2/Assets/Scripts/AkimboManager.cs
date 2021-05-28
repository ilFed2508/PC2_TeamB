using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AkimboManager : MonoBehaviour
{
    
    private PlayerController playerController;
    public GameObject Akimbo;
    private Animator Camera;
    public GameObject AkimboSlot;
    public GameObject ArmaSlot;
    public float Timer;
    public float CopyTimer;
    public float RefreshToAddAkimbo;
    public float copyRefresh;

    public bool AddAkimbo;
    private bool StartTimer;
    private bool StartRefresh;
    // Start is called before the first frame update
    void Start()
    {
        StartTimer = false;
        AddAkimbo = true;
        StartRefresh = false;
        playerController = GameObject.FindObjectOfType<PlayerController>();
        Camera = GameObject.Find("WeaponSlot").GetComponent<Animator>();      
    }

    // Update is called once per frame
    void Update()
    {
        if (StartTimer == true)
        {
            Timer -= Time.deltaTime;
        }
        if (AddAkimbo && Timer > 0)
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                AkimboWeapon(); 
                if(StartTimer == true)
                {
                    Timer -= Time.deltaTime;
                }
            }                       
        }

        if (Timer < 0f)
        {                 
            DestroyAkimbo();
            Timer = CopyTimer;
            
        }
        if (StartRefresh == true)
        {
            RefreshToAddAkimbo -= Time.deltaTime;
        }

        if ( RefreshToAddAkimbo < 0)
        {
           AddAkimbo = true;         
           RefreshToAddAkimbo = copyRefresh;
           StartRefresh = false;
        }        

    }


    public void AkimboWeapon()
    {
        StartTimer = true;
        AkimboSlot.SetActive(true);
        ArmaSlot.SetActive(false);
        Camera.Play("SwitchWeapon");
        //destroy current Weapon         
        GameObject CurrentNewWeapon = Instantiate(Akimbo, playerController.WeaponSlotAkimbo);
        //set current ranged weapon to the one you instatiated
        playerController.playerShooting.CurrentRagedWeapon = CurrentNewWeapon.GetComponent<RangedWeapon>();
        //setup new current ammo
        playerController.playerShooting.CurrentRagedWeapon.SetupCurrentAmmo();
        //update digetic ammo UI
        playerController.playerShooting.DiegeticAmmo = playerController.playerShooting.CurrentRagedWeapon.GetComponentInChildren<TextMeshProUGUI>();       
    }

    public void DestroyAkimbo()
    {
        
       AddAkimbo = false;
       StartTimer = false;
       StartRefresh = true;
       ArmaSlot.SetActive(true);
       AkimboSlot.SetActive(false);
       Camera.Play("SwitchWeapon");
       Timer = CopyTimer;
        //destroy current Weapon
       Destroy(playerController.playerShooting.CurrentRagedWeapon.gameObject);
       playerController.playerShooting.CurrentRagedWeapon = playerController.WeaponSlot.GetComponentInChildren<RangedWeapon>();
       //setup new current ammo
       playerController.playerShooting.CurrentRagedWeapon.SetupCurrentAmmo();
       //update digetic ammo UI
       playerController.playerShooting.DiegeticAmmo = playerController.playerShooting.CurrentRagedWeapon.GetComponentInChildren<TextMeshProUGUI>();
              
    }

    
}
