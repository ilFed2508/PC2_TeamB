using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerShooting : MonoBehaviour
{
    public RangedWeapon CurrentRagedWeapon;
    //Da eliminare più avanti
    public Animator anim;
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
        anim = GameObject.FindGameObjectWithTag("Weapon").GetComponent<Animator>();
        //-----------------------
        CurrentRagedWeapon.UpdateFireRateoValue();
        CurrentRagedWeapon.UpdateTotalDamageValue();
        UpdateAmmoUI();
        UpdateDiegeticUI();

        //Execute shooting
        if (Input.GetMouseButtonDown(0) && CurrentRagedWeapon.ShootingType.IsAutomatic == false)
        {
            //Da eliminare più avanti
            anim.Play("ShootAR");
            CurrentRagedWeapon.ShootingType.ShootingAction(CurrentRagedWeapon);
            
        }
        if (Input.GetMouseButton(0) && CurrentRagedWeapon.ShootingType.IsAutomatic == true)
        {
            CurrentRagedWeapon.ShootingType.ShootingAction(CurrentRagedWeapon);
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
