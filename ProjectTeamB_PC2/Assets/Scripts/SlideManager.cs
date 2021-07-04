using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlideManager : MonoBehaviour
{
    private CharacterController controller;
    public float slideSpeed;
    public bool isSliding;

    public float TimeSlide;
    public float TimeToSlide;

    public float CopyTimeSlide;
    public float CopyTimeToSlide;

    private Animator weaponSlotCam;

    public GameObject MarketPanel,SlideIcon,SlideIconOFF, EmptyIcon;


    [SerializeField] Image[] images = default;
    [Min(0)]
    [SerializeField] float waitBeforeStartFadeIn = 1;
    [Min(0)]
    [SerializeField] float timeToFadeIn = 1;
    [Min(0)]
    [SerializeField] float timeToFadeOut = 1;


    void Start()
    {
        controller = GetComponent<CharacterController>();
        weaponSlotCam = GameObject.Find("WeaponSlot").GetComponent<Animator>();
        isSliding = false;
    }

    
    void Update()
    {
        if (isSliding)
        {
            //EmptyIcon.SetActive(false);
            if (TimeSlide > 0f && controller.isGrounded)
            {
                SlideIcon.SetActive(true);
                SlideIconOFF.SetActive(false);
                if (Input.GetMouseButton(1) || Input.GetButton("Xbox_LB"))
                {
                    Slide();
                }
            }
            if (TimeSlide <= 0f)
            {
                SlideIcon.SetActive(false);
                SlideIconOFF.SetActive(true);
                TimeToSlide -= Time.deltaTime;
                if (TimeToSlide <= 0f)
                {
                    TimeSlide = CopyTimeSlide;
                    TimeToSlide = CopyTimeToSlide;
                }
            }
        } 
        if (!isSliding)
        {
            SlideIcon.SetActive(false);
            SlideIconOFF.SetActive(false);
            //EmptyIcon.SetActive(true);
        }   
    } 
    

    public void Slide()
    {
        AudioManager.instance.Play("Dash");

        StartCoroutine(FadeInAndOut());

        TimeSlide -= Time.deltaTime;
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        
        Vector3 Lateral = transform.TransformDirection(Vector3.right);
       

        float curSpeed = slideSpeed * Input.GetAxis("Vertical");
        float LatSpeed = slideSpeed * Input.GetAxis("Horizontal");

        controller.SimpleMove(forward * curSpeed);
        controller.SimpleMove(Lateral * LatSpeed);        
       

        if (curSpeed > 0f)
        {
            weaponSlotCam.Play("SlideFarward");
        }
        if(-curSpeed > -0f)
        {
            weaponSlotCam.Play("SlideBack");
        }
        if(LatSpeed > 0f)
        {
            weaponSlotCam.Play("RightSlide");           
        }
        if (-LatSpeed > -0f)
        {
            weaponSlotCam.Play("LeftSlide");
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
