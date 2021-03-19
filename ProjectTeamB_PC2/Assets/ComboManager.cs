using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComboManager : MonoBehaviour
{
    public float livelloCombo;
    public float aggiuntaDanno;
    private float danno;
    private float dannoEffettivo;
    public float tempoPerScalare;
    public float tempoRestart;

    public Text LivelloCombo;

    public RangedWeapon CurrentRagedWeapon;

    private PlayerController playerController;

    public 
    // Start is called before the first frame update
    void Start()
    {
             
        playerController = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        CurrentRagedWeapon = FindObjectOfType<RangedWeapon>();
        danno = CurrentRagedWeapon.weaponData.Damage;
        dannoEffettivo = danno;
        ComboSystem();
        //ComboDamage();
    }


    private void ComboSystem()
    {
        CurrentRagedWeapon = playerController.playerShooting.CurrentRagedWeapon;

        if (CurrentRagedWeapon.CurrentAmmo <= 0)
        {
            livelloCombo = 0f;
        }

        Debug.Log("Scalo" + tempoPerScalare);
        LivelloCombo.text = livelloCombo.ToString("F0");

        if (livelloCombo > 0f)
        {
            

            tempoPerScalare -= Time.deltaTime;
            if (tempoPerScalare < 0f)
            {
                livelloCombo = livelloCombo - 1f;
                tempoPerScalare = tempoRestart;

                if (livelloCombo <= 0f)
                {
                    livelloCombo = 0f;
                }

            }
        }
    }


    public void ComboDamage()
    {
        if(livelloCombo == 0)
        {
            
        }
        if(livelloCombo == 1 || livelloCombo == 2 || livelloCombo == 3)
        {
            dannoEffettivo = dannoEffettivo + aggiuntaDanno;
        }
        if (livelloCombo == 4 || livelloCombo == 5 || livelloCombo == 6)
        {
            dannoEffettivo = dannoEffettivo + aggiuntaDanno * 2;
        }
    }
}
