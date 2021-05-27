using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComboManager : MonoBehaviour
{
    public int livelloCombo;
    public float aggiuntaDanno;
    private float danno;
    public float tempoPerScalare;
    public float tempoRestart;
    private float DannoIniziale;

    public Text LivelloCombo;

    public int[]Livellocombo;

    public RangedWeapon CurrentRagedWeapon;

    private PlayerController playerController;

    public GameObject[] Sprite;

    [HideInInspector]
    public int i;

    


    // Start is called before the first frame update
    void Start()
    {
             
        playerController = FindObjectOfType<PlayerController>();
        CurrentRagedWeapon = FindObjectOfType<RangedWeapon>();
        DannoIniziale = playerController.playerShooting.CurrentRagedWeapon.weaponData.Damage;

    }

    // Update is called once per frame
    void Update()
    {
        
        i = livelloCombo;
        danno = playerController.playerShooting.CurrentRagedWeapon.weaponData.StartingDamage;
        ComboSystem();
        ResetComboDamage();

        Debug.Log("cazzo" + i);
    }


    private void ComboSystem()
    {
        CurrentRagedWeapon = playerController.playerShooting.CurrentRagedWeapon;

        if (CurrentRagedWeapon.CurrentAmmo <= 0)
        {
            livelloCombo = 0;
        }

        //Debug.Log("Scalo" + tempoPerScalare);
        LivelloCombo.text = livelloCombo.ToString("F0");

        if (livelloCombo > 0f)
        {

            tempoPerScalare -= Time.deltaTime;
            if (tempoPerScalare < 0f)
            {
                livelloCombo = livelloCombo - 1;
                
                if (System.Array.IndexOf(Livellocombo, livelloCombo) != -1)
                {
                    playerController.playerShooting.CurrentRagedWeapon.weaponData.Damage -= aggiuntaDanno;
                }               
                tempoPerScalare = tempoRestart;

                if (livelloCombo <= 0f)
                {
                    livelloCombo = 0;
                }

            }
        }
    }


    public void ComboDamage()
    {
      
        if (System.Array.IndexOf(Livellocombo, livelloCombo) != -1)
        {
            playerController.playerShooting.CurrentRagedWeapon.weaponData.Damage  += aggiuntaDanno;
        }

        //if (livelloCombo == 1)
        //{
        //    playerController.playerShooting.CurrentRagedWeapon.weaponData.Damage += aggiuntaDanno;
        //}
        //if (livelloCombo == 2)
        //{
        //    playerController.playerShooting.CurrentRagedWeapon.weaponData.Damage += aggiuntaDanno;
        //}
        //if (livelloCombo == 3)
        //{
        //    playerController.playerShooting.CurrentRagedWeapon.weaponData.Damage += aggiuntaDanno;
        //}
    }

    public void ResetComboDamage()
    {
        if (livelloCombo == 0)
        {
            playerController.playerShooting.CurrentRagedWeapon.weaponData.Damage = playerController.playerShooting.CurrentRagedWeapon.weaponData.StartingDamage;
        }
    }


   
}
