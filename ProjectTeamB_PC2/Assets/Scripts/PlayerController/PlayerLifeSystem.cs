using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;

public class PlayerLifeSystem : MonoBehaviour
{
    /// <summary>
    /// Player current Hp
    /// </summary>
    public float PlayerCurrentHP;

    public float TimeMultiplier;
    /// <summary>
    /// Hp value at the start of the game
    /// </summary>
    public float PlayerStartingHP;
    /// <summary>
    /// time gain for killing an enemy
    /// </summary>
    public float EnemyTimeGain;

    public float PlayerHPscore;

    private SlowerHpManager MyPowerupDamage;

    //variabili UI da eliminare in futuro
    public Text LifeText;
    public GameObject DeathPanel;

    //LifeBar - joe
    public Slider LifeBar;

    //Warning Image_Animation - Joe
    public Image Warning;

    public GameObject HUD, WarningDeactiveted, WeaponSlots, EPickUP, HitContainer, PausePanel;
    
    //public PlayableDirector ScreenNoise;

    private GameObject comboCounter, timeLineScreenNoise, timeLineScreenNoise_ , crosshair;


    // Start is called before the first frame update
    void Start()
    {
        //PlayerCurrentHP = PlayerCurrentHP;
        comboCounter = GameObject.Find("Canvas(Sprite-Combo)");
        crosshair = GameObject.Find("Canvas Cross");

        timeLineScreenNoise = GameObject.Find("timeLine_screenNoise");
        MyPowerupDamage = FindObjectOfType<SlowerHpManager>();
        //timeLineScreenNoise_ = GameObject.Find("DeathAnimation_2");
        //timeLineScreenNoise_.SetActive(false);

        //ScreenNoise = GetComponent<PlayableDirector>();
        //ScreenNoise.Stop();
    }

    /// <summary>
    /// Countdown of the player Life 
    /// </summary>
    public void LifeTimer()
    {
        PlayerHPscore = PlayerStartingHP - PlayerCurrentHP;

        if (PlayerCurrentHP < PlayerStartingHP)
        {
            PlayerCurrentHP += Time.deltaTime * TimeMultiplier;
            //LifeText.text = PlayerCurrentHP.ToString("F0");

            //screenNoise.SetActive(false);
            timeLineScreenNoise.SetActive(false);
            //timeLineScreenNoise_.SetActive(false);

            //LifeBar - joe
            LifeBar.maxValue = PlayerStartingHP * 100;
            LifeBar.value = PlayerCurrentHP * 100;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            //screenNoise.SetActive(true);
            timeLineScreenNoise.SetActive(true);
            StartCoroutine(NoiseScreen());
            Time.timeScale = 0;
            //DeathPanel.SetActive(true);

            //HUD.SetActive(false);
            //PausePanel.SetActive(false);
            Destroy(HUD);
            Destroy(PausePanel);
            Destroy(comboCounter);
            Destroy(crosshair);
            WeaponSlots.SetActive(false);
            WarningDeactiveted.SetActive(false);
            EPickUP.SetActive(false);
            HitContainer.SetActive(false);
        }

        //Warning Image_Animation - Joe
        if (PlayerCurrentHP >= 18)
        {
            Warning.enabled = true;
        }
        else
        {
            Warning.enabled = false;
        }

        if(PlayerCurrentHP < 0 )
        {
            PlayerCurrentHP = 0;
        }
    }

    public IEnumerator NoiseScreen()
    {
        yield return new WaitForSecondsRealtime(1.5f);
        Destroy(timeLineScreenNoise);
        //timeLineScreenNoise_.SetActive(true);

        //yield return new WaitForSecondsRealtime(1.0f);
        //Destroy(timeLineScreenNoise_);
        DeathPanel.SetActive(true);
    }

    public void DamagePlayer(float Amount)
    {       
        if (MyPowerupDamage.SlowerHpIsActive)
        {
            PlayerCurrentHP += Amount + MyPowerupDamage.AddDamage;
        }
        else
        {
            PlayerCurrentHP += Amount;
        }
    }
}
