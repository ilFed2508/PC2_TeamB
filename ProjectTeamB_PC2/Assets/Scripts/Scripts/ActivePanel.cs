using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivePanel : MonoBehaviour
{

    [SerializeField] Image[] images = default;
    [Min(0)]
    [SerializeField] float waitBeforeStartFadeIn = 1;
    [Min(0)]
    [SerializeField] float timeToFadeIn = 1;
    [Min(0)]
    [SerializeField] float timeToFadeOut = 1;


    
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


    //Codice di proprietà di Alessio Manna,Per ogni utilizzo contattare il sottoscritto al numero 3334578956 o tramite il profilo  
    //Linkedin con nome "Non sono un pagliaccio LO GIURO!" Grazie per aver visionato il mio codice un saluto.

}
