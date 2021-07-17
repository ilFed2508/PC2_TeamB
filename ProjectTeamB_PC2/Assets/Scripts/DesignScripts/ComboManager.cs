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

    public int[] Livellocombo;
    public float ComboTime;

    public RangedWeapon CurrentRagedWeapon;

    public WeaponData AR, SMG, MINIGUN, SHOTGUN;

    private PlayerController playerController;

    [HideInInspector]
    public SpriteDatabase MySprite;

    public GameObject[] Sprite;

    public GameObject ZeroVFX;

    private DroneShake MyLevelZero;

    [HideInInspector]
    public int i;




    // Start is called before the first frame update
    void Start()
    {

        playerController = FindObjectOfType<PlayerController>();
        CurrentRagedWeapon = FindObjectOfType<RangedWeapon>();
        DannoIniziale = playerController.playerShooting.CurrentRagedWeapon.weaponData.Damage;
        MyLevelZero = GameObject.Find("Combo Level").GetComponent<DroneShake>();

    }

    // Update is called once per frame
    void Update()
    {
        MySprite = FindObjectOfType<SpriteDatabase>();
        i = livelloCombo;
        danno = playerController.playerShooting.CurrentRagedWeapon.weaponData.StartingDamage;
        ComboSystem();
        ResetComboDamage();
        ActiveComboSprite();
        FixDataStartingDamage();
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

            tempoPerScalare -= Time.deltaTime * ComboTime;
            if (tempoPerScalare < 0f)
            {
                livelloCombo = livelloCombo - 1;

                if (System.Array.IndexOf(Livellocombo, livelloCombo) != -1)
                {
                    AR.Damage -= aggiuntaDanno;
                    SMG.Damage -= aggiuntaDanno;
                    MINIGUN.Damage -= aggiuntaDanno;
                    SHOTGUN.Damage -= aggiuntaDanno;
                    DeactiveComboSprite();
                }
                tempoPerScalare = tempoRestart;

                if (livelloCombo <= 0f)
                {
                    livelloCombo = 0;
                }

                if(livelloCombo == 0f)
                {
                    AudioManager.instance.Play("ZeroFeed");
                    MyLevelZero.enabled = true;
                    MyLevelZero.gameObject.GetComponent<Text>().color = Color.red;
                    StartCoroutine(lateCall());
                    ZeroVFX.SetActive(true);
                }

            }
        }
    }


    public void ComboDamage()
    {

        if (System.Array.IndexOf(Livellocombo, livelloCombo) != -1)
        {

            AR.Damage += aggiuntaDanno;
            SMG.Damage += aggiuntaDanno;
            MINIGUN.Damage += aggiuntaDanno;
            SHOTGUN.Damage += aggiuntaDanno;
            MySprite.DamageUp.SetActive(true);
            AudioManager.instance.Play("ComboUP");
        }
    }

    public void ResetComboDamage()
    {
        if (livelloCombo == 0)
        {
            AR.Damage = AR.StartingDamage;
            SMG.Damage = SMG.StartingDamage;
            MINIGUN.Damage = MINIGUN.StartingDamage;
            SHOTGUN.Damage = SHOTGUN.StartingDamage;
            for (int i = 0; i < MySprite.SpriteCombo.Length; i++)
            {
                MySprite.SpriteCombo[i].SetActive(false);
            }

            StartCoroutine(lateCall());
        }
    }

    #region SpriteComboDamage
    public void ActiveComboSprite()
    {
        if (livelloCombo >= Livellocombo[0])
        {
            MySprite.SpriteCombo[0].SetActive(true);
        }
        if (livelloCombo >= Livellocombo[1])
        {
            MySprite.SpriteCombo[1].SetActive(true);
        }
        if (livelloCombo >= Livellocombo[2])
        {
            MySprite.SpriteCombo[2].SetActive(true);
        }
        if (livelloCombo >= Livellocombo[3])
        {
            MySprite.SpriteCombo[3].SetActive(true);
        }
        if (livelloCombo >= Livellocombo[4])
        {
            MySprite.SpriteCombo[4].SetActive(true);
        }
        if (livelloCombo >= Livellocombo[5])
        {
            MySprite.SpriteCombo[5].SetActive(true);
        }
        if (livelloCombo >= Livellocombo[6])
        {
            MySprite.SpriteCombo[6].SetActive(true);
        }
        if (livelloCombo >= Livellocombo[7])
        {
            MySprite.SpriteCombo[7].SetActive(true);
        }
        if (livelloCombo >= Livellocombo[8])
        {
            MySprite.SpriteCombo[8].SetActive(true);
        }
        if (livelloCombo >= Livellocombo[9])
        {
            MySprite.SpriteCombo[9].SetActive(true);
        }


    }

    public void DeactiveComboSprite()
    {
        if (livelloCombo < Livellocombo[0])
        {
            MySprite.SpriteCombo[0].SetActive(false);
        }
        if (livelloCombo < Livellocombo[1])
        {
            MySprite.SpriteCombo[1].SetActive(false);
        }
        if (livelloCombo < Livellocombo[2])
        {
            MySprite.SpriteCombo[2].SetActive(false);
        }
        if (livelloCombo < Livellocombo[3])
        {
            MySprite.SpriteCombo[3].SetActive(false);
        }
        if (livelloCombo < Livellocombo[4])
        {
            MySprite.SpriteCombo[4].SetActive(false);
        }
        if (livelloCombo < Livellocombo[5])
        {
            MySprite.SpriteCombo[5].SetActive(false);
        }
        if (livelloCombo < Livellocombo[6])
        {
            MySprite.SpriteCombo[6].SetActive(false);
        }
        if (livelloCombo < Livellocombo[7])
        {
            MySprite.SpriteCombo[7].SetActive(false);
        }
        if (livelloCombo < Livellocombo[8])
        {
            MySprite.SpriteCombo[8].SetActive(false);
        }
        if (livelloCombo < Livellocombo[9])
        {
            MySprite.SpriteCombo[9].SetActive(false);
        }


    }





    #endregion
    IEnumerator lateCall()
    {
        yield return new WaitForSeconds(MyLevelZero.shakeDuration);
        MyLevelZero.gameObject.GetComponent<Text>().color = Color.white;
    }


    public void FixDataStartingDamage()
    {
        if(AR.Damage < AR.StartingDamage)
        {
            AR.Damage = AR.StartingDamage;
        }
        if (SMG.Damage < SMG.StartingDamage)
        {
            SMG.Damage = SMG.StartingDamage;
        }
        if (MINIGUN.Damage < MINIGUN.StartingDamage)
        {
            MINIGUN.Damage = MINIGUN.StartingDamage;
        }
        if (SHOTGUN.Damage < SHOTGUN.StartingDamage)
        {
            SHOTGUN.Damage = SHOTGUN.StartingDamage;
        }
    }

}



