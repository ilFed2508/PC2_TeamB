using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public GameObject MarketPanel,SlideIcon;

    
   
    void Start()
    {
        controller = GetComponent<CharacterController>();
        weaponSlotCam = GameObject.Find("WeaponSlot").GetComponent<Animator>();
        isSliding = false;
    }

    
    void Update()
    {     
        if (isSliding && TimeSlide>0f && controller.isGrounded)
        {
            SlideIcon.SetActive(true);
            if (Input.GetKey(KeyCode.LeftShift))
            {
                Slide();
            }
        }
        if(TimeSlide <= 0f)
        {
            SlideIcon.SetActive(false);
            TimeToSlide -= Time.deltaTime;
            if(TimeToSlide <= 0f)
            {
                TimeSlide = CopyTimeSlide;
                TimeToSlide = CopyTimeToSlide;
            }
        }
    } 
    

    public void Slide()
    {
        

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
}
