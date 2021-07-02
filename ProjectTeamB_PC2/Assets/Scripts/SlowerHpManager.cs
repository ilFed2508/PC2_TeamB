using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlowerHpManager : MonoBehaviour
{
    public bool SlowerHpIsActive;
    private bool IconIsActive;


    private PlayerLifeSystem MyLife;

    [Range(0.0f, 1.0f)]
    public float TimeSpeedMultiplier;
    public float AddDamage;

    private float CopyTimeMultiplier;

    public GameObject SlowerHpIcon;

    public Image FeedSHP;

    // Start is called before the first frame update
    void Start()
    {       
        MyLife = FindObjectOfType<PlayerLifeSystem>();
        CopyTimeMultiplier = MyLife.TimeMultiplier;
        SlowerHpIsActive = false;
        IconIsActive = true;
    }

    // Update is called once per frame
    void Update()
    {

        if(SlowerHpIsActive == true)
        {

            if (IconIsActive == true)
            {
               SlowerHpIcon.SetActive(true);
                if (Input.GetMouseButtonDown(1) || Input.GetButton("Xbox_LB"))
                {
                    AudioManager.instance.Play("SlowerHP");
                    MyLife.TimeMultiplier = TimeSpeedMultiplier;
                    SlowerHpIcon.SetActive(false);
                    IconIsActive = false;
                    StartCoroutine(FeedAnim(3f,3f));                  
                }
            }  
            
        }

        if(SlowerHpIsActive == false)
        {
            MyLife.TimeMultiplier = CopyTimeMultiplier;
            SlowerHpIcon.SetActive(false);
            IconIsActive = true;
            StartCoroutine(FeedAnim2(3f, 3f));
        }
    }

    IEnumerator FeedAnim(float Duration, float TimeToLerp)
    {
        float TimeC = 0;

        while (TimeC < Duration)
        {
            FeedSHP.fillAmount = Mathf.Lerp(FeedSHP.fillAmount,1, Time.deltaTime * TimeToLerp);

            TimeC += Time.deltaTime;

            yield return null;
        }
    }

    IEnumerator FeedAnim2(float Duration, float TimeToLerp)
    {
        float TimeC = 0;

        while (TimeC < Duration)
        {
            FeedSHP.fillAmount = Mathf.Lerp(FeedSHP.fillAmount, 0, Time.deltaTime * TimeToLerp);

            TimeC += Time.deltaTime;

            yield return null;
        }
    }
}
