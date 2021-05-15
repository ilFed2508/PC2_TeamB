using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLifeSystem : MonoBehaviour
{
    //Davide
    private SafeZone safe;
    private SafeZone safe2;
    private SafeZone safe3;


    /// <summary>
    /// Player current Hp
    /// </summary>
    public float PlayerCurrentHP;
    /// <summary>
    /// Hp value at the start of the game
    /// </summary>
    public float PlayerStartingHP;
    /// <summary>
    /// time gain for killing an enemy
    /// </summary>
    public float EnemyTimeGain;


    //variabili UI da eliminare in futuro
    public Text LifeText;
    public GameObject DeathPanel;

    //LifeBar - joe
    public Slider LifeBar;

    //Warning Image_Animation - Joe
    public Image Warning;

    public GameObject HUD, WarningDeactiveted, WeaponSlots, EPickUP, HitContainer, PausePanel;
    private GameObject comboCounter;


    // Start is called before the first frame update
    void Start()
    {
        //PlayerCurrentHP = PlayerCurrentHP;
        comboCounter = GameObject.Find("Canvas(Sprite-Combo)");
    }

    /// <summary>
    /// Countdown of the player Life 
    /// </summary>
    public void LifeTimer()
    {
        if (PlayerCurrentHP > 0)
        {
            LifeText.text = PlayerCurrentHP.ToString("F0");
            PlayerCurrentHP -= Time.deltaTime;

            //LifeBar - joe
            LifeBar.maxValue = PlayerStartingHP;
            LifeBar.value = PlayerCurrentHP;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0;
            DeathPanel.SetActive(true);

            //HUD.SetActive(false);
            //PausePanel.SetActive(false);
            Destroy(this.HUD);
            Destroy(this.PausePanel);
            Destroy(this.comboCounter);
            WeaponSlots.SetActive(false);
            WarningDeactiveted.SetActive(false);
            EPickUP.SetActive(false);
            HitContainer.SetActive(false);
        }

        //Warning Image_Animation - Joe
        if (PlayerCurrentHP <= 6)
        {
            Warning.enabled = true;
        }
        else
        {
            Warning.enabled = false;
        }
    }

    public void DamagePlayer(float Amount)
    {
        PlayerCurrentHP -= Amount;
    }
}
