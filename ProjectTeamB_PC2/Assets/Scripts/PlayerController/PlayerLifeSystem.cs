using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;

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
    
    //public PlayableDirector ScreenNoise;

    private GameObject comboCounter, timeLineScreenNoise, timeLineScreenNoise_ , crosshair;


    // Start is called before the first frame update
    void Start()
    {
        //PlayerCurrentHP = PlayerCurrentHP;
        comboCounter = GameObject.Find("Canvas(Sprite-Combo)");
        crosshair = GameObject.Find("Canvas Cross");

        timeLineScreenNoise = GameObject.Find("timeLine_screenNoise");
        timeLineScreenNoise_ = GameObject.Find("DeathAnimation_2");
        timeLineScreenNoise_.SetActive(false);

      //ScreenNoise = GetComponent<PlayableDirector>();
      //ScreenNoise.Stop();
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

            //screenNoise.SetActive(false);
            timeLineScreenNoise.SetActive(false);
            timeLineScreenNoise_.SetActive(false);

            //LifeBar - joe
            LifeBar.maxValue = PlayerStartingHP;
            LifeBar.value = PlayerCurrentHP;
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
        if (PlayerCurrentHP <= 6)
        {
            Warning.enabled = true;
        }
        else
        {
            Warning.enabled = false;
        }
    }

    public IEnumerator NoiseScreen()
    {
        yield return new WaitForSecondsRealtime(1.0f);
        Destroy(timeLineScreenNoise);
        timeLineScreenNoise_.SetActive(true);

        yield return new WaitForSecondsRealtime(1.0f);
        Destroy(timeLineScreenNoise_);
        DeathPanel.SetActive(true);
    }

    public void DamagePlayer(float Amount)
    {
        PlayerCurrentHP -= Amount;
    }
}
