using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerShooting : MonoBehaviour
{
    public RangedWeapon CurrentRagedWeapon;
    private bool JoystickInputActivated;
    //Da eliminare più avanti
    //private Animator anim;
    //-------------------------
    //temporary UI Variable
    public Text AmmoText;
    public GameObject AmmoSwitchText;
    public TextMeshProUGUI DiegeticAmmo;

    //variabile da modificare
    public WeaponDatabase weaponDatabase;

    // Start is called before the first frame update
    void Start()
    {
        weaponDatabase = FindObjectOfType<WeaponDatabase>();
        CurrentRagedWeapon.ShootingType.SetupCanWeaponShoot();
        CurrentRagedWeapon.SetupCurrentAmmo();

        foreach(WeaponData weapon in weaponDatabase.LogicWeaponsDatabase)
        {
            weapon.Damage = weapon.StartingDamage;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        //Da eliminare più avanti
        //anim = GameObject.FindGameObjectWithTag("Weapon").GetComponent<Animator>();
        //-----------------------
        CurrentRagedWeapon.UpdateFireRateoValue();
        CurrentRagedWeapon.UpdateTotalDamageValue();
        UpdateAmmoUI();
        UpdateDiegeticUI();

        //Execute shooting
        if ((Input.GetAxis("Xbox_RT") > 0 || Input.GetMouseButtonDown(0)) && CurrentRagedWeapon.ShootingType.IsAutomatic == false)
        {
            if(JoystickInputActivated == false)
            {
                CurrentRagedWeapon.ShootingType.ShootingAction(CurrentRagedWeapon);
                JoystickInputActivated = true;
            }            
            //Da eliminare più avanti
            //anim.Play("ShootAR(Def)");

        }
        if ((Input.GetAxis("Xbox_RT") > 0 || Input.GetMouseButton(0)) && CurrentRagedWeapon.ShootingType.IsAutomatic == true)
        {
            CurrentRagedWeapon.ShootingType.ShootingAction(CurrentRagedWeapon);
        }
        if(Input.GetAxis("Xbox_RT") <= 0)
        {
            JoystickInputActivated = false;
        }
    }

    public void UpdateAmmoUI()
    {
        AmmoText.text = CurrentRagedWeapon.CurrentAmmo.ToString("F0");

        if(CurrentRagedWeapon.CurrentAmmo <= 0)
        {
            AmmoSwitchText.SetActive(true);
        }
        else
        {
            AmmoSwitchText.SetActive(false);
        }
    }

    public void UpdateDiegeticUI()
    {
        DiegeticAmmo.SetText(CurrentRagedWeapon.CurrentAmmo.ToString("F0"));
    }
}
