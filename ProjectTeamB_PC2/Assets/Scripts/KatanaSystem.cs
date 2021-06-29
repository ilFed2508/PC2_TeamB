using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KatanaSystem : MonoBehaviour
{


    private Animator MyKatanaAnimator;

    public float SlashSpeed,TimeToUseKatana,CopyTimeToUseKatana;

    private PlayerController MyPlayer;

    public GameObject KatanaContenitore;
    private Animator WeaponSlot;

    Vector3 HitPoint, VoidPoint;

    private MeleePercentuale MyBool;

    

    public string VoidHit;



    [SerializeField] Image[] images = default;
    [Min(0)]
    [SerializeField] float waitBeforeStartFadeIn = 1;
    [Min(0)]
    [SerializeField] float timeToFadeIn = 1;
    [Min(0)]
    [SerializeField] float timeToFadeOut = 1;

    private void Start()
    {
        MyKatanaAnimator = GetComponent<Animator>();
        MyPlayer = FindObjectOfType<PlayerController>();
        WeaponSlot = GameObject.Find("WeaponSlot").GetComponent<Animator>();
        MyBool = FindObjectOfType<MeleePercentuale>();
        
    }

    private void Update()
    {
        if(TimeToUseKatana > 0)
        {
            TimeToUseKatana -= Time.deltaTime;
        }
        if(TimeToUseKatana < 0)
        {
            TimeToUseKatana = 0;
        }
        if (Input.GetMouseButtonDown(1) && TimeToUseKatana <=0)
        {           
            slash();
        }
        
        if(MyPlayer.gameObject.transform.position == HitPoint)
        {
            StopAllCoroutines();
        }
    }



    public void slash()
    {
        MyBool.NonPossoMenare = true;

        WeaponSlot.Play("Melee-WeaponSlot");
        MyKatanaAnimator.Play("KatanaHit");
       


        AudioManager.instance.Play(VoidHit);

        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 3f));
        RaycastHit Hit;
        

        if (Physics.Raycast(ray, out Hit))
        {
             HitPoint = Hit.point;
        }
        else
        {
            VoidPoint = ray.GetPoint(80);
        }

        if (Hit.collider.CompareTag("Enemy"))
        {
            StartCoroutine(SlashLerp(0.5f));
            StartCoroutine(FadeInAndOut());
            //MyKatanaAnimator.Play("KatanaHit");
        }
        TimeToUseKatana = CopyTimeToUseKatana;
                     
    }

    public void UseMelee()
    {
        MyBool.NonPossoMenare = false;
    }

    IEnumerator SlashLerp(float Duration)
    {
        
        float TimeC = 0;

        while (TimeC < Duration)
        {
            MyPlayer.gameObject.transform.position = Vector3.Lerp(MyPlayer.gameObject.transform.position, HitPoint, Time.fixedDeltaTime * SlashSpeed);

            TimeC += Time.deltaTime;

            yield return null;
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
