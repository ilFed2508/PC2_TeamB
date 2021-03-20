using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShooting : MonoBehaviour
{
    public RangedWeapon CurrentRagedWeapon;
    //Da eliminare più avanti
    public Animator anim;
    //-------------------------
    //temporary UI Variable
    public Text AmmoText;
    public GameObject AmmoSwitchText;

    // Start is called before the first frame update
    void Start()
    {
        
        CurrentRagedWeapon.ShootingType.SetupCanWeaponShoot();
        CurrentRagedWeapon.SetupCurrentAmmo();
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
}
