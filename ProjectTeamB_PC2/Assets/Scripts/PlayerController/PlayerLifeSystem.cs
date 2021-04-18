using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLifeSystem : MonoBehaviour
{
    //Davide
    private SafeZone safe;
    private SafeZone safe2;


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

    public GameObject lifeBar, WeaponIcon, AmmoCounter, Combo, PausePanel, WarningDeactiveted;


    // Start is called before the first frame update
    void Start()
    {
        PlayerCurrentHP = PlayerStartingHP;

        //Davide
       safe = GameObject.Find("SafeArea1").GetComponent<SafeZone>();
       safe.playerLife = this;
       safe2 = GameObject.Find("SafeArea2").GetComponent<SafeZone>();
       safe2.playerLife = this;
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

            lifeBar.SetActive(false);
            WeaponIcon.SetActive(false);
            AmmoCounter.SetActive(false);
            Combo.SetActive(false);
            PausePanel.SetActive(false);
            WarningDeactiveted.SetActive(false);
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
