using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MedikitManager : MonoBehaviour
{
    private PlayerLifeSystem MyLife;
    public bool CanUseMedikit;

    public int NumberOfMedikit;
    public float MedikitEffect;

    public GameObject MedikitIcon,AnimationBar;
    public Text NumberOfMedikitText;

    [HideInInspector]
    public int NumberOfMedikitCopy;


    [SerializeField] Image[] images = default;
    [Min(0)]
    [SerializeField] float waitBeforeStartFadeIn = 1;
    [Min(0)]
    [SerializeField] float timeToFadeIn = 1;
    [Min(0)]
    [SerializeField] float timeToFadeOut = 1;

    void Start()
    {
        MyLife = FindObjectOfType<PlayerLifeSystem>();
        CanUseMedikit = false;
        NumberOfMedikitCopy = NumberOfMedikit;
    }

    // Update is called once per frame
    void Update()
    {
        
        NumberOfMedikitText.text ="X" + NumberOfMedikit.ToString();
        if (CanUseMedikit)
        {
            
            MedikitIcon.SetActive(true);
            if(Input.GetMouseButtonDown(1) && NumberOfMedikit > 0)
            {
                MyLife.PlayerCurrentHP += MedikitEffect;
                AudioManager.instance.Play("Medikit");
                AnimationBar.SetActive(true);
                StartCoroutine(FadeInAndOut());
                NumberOfMedikit -= 1;
            }
        }

        if (NumberOfMedikit == 0)
        {           
            CanUseMedikit = false;
            MedikitIcon.SetActive(false);
        }
        if(!CanUseMedikit)
        {
            MedikitIcon.SetActive(false);
        }
    }








    IEnumerator FadeInAndOut()
    {
        //start alpha to 0
        ChangeAlpha(0);

        //wait before start fade in
        yield return new WaitForSeconds(waitBeforeStartFadeIn);

        //fade in
        float delta = 0;
        while (delta < 1)
        {
            delta = Fade(0, 1, delta, timeToFadeIn);

            yield return null;
        }

        //final alpha to 1
        ChangeAlpha(1);


        //fade out
        delta = 0;
        while (delta < 1)
        {
            delta = Fade(1, 0, delta, timeToFadeOut);

            yield return null;
        }

        //final alpha to 0
        ChangeAlpha(0);


    }

    float Fade(float from, float to, float delta, float duration)
    {
        //speed based to duration
        delta += Time.deltaTime / duration;

        //set alpha from to
        float alpha = Mathf.Lerp(from, to, delta);
        ChangeAlpha(alpha);

        return delta;
    }

    void ChangeAlpha(float alpha)
    {
        //foreach image, change alpha
        foreach (Image image in images)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, alpha);
        }
    }
}
