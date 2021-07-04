using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerUpManager : MonoBehaviour
{
    private PlayerMovement MyMovement;

    public float SpeedIncrease;
    public float AirSpeedIncrease;

    private float CopyGroundSpeed;
    private float CopyAirSpeed;
    private bool CanIncrease;

    public GameObject IconPoweUp,EmptyIcon;

    public bool Faster;

    public Camera MyFieldOfView;
    public float NewFieldOfView;


    // Start is called before the first frame update
    void Start()
    {
        MyMovement = FindObjectOfType<PlayerMovement>();
        CopyAirSpeed = MyMovement.AirSpeed;
        CopyGroundSpeed = MyMovement.GroundSpeed;
        Faster = false;
        CanIncrease = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Faster == true )
        {
            if (CanIncrease == true)
            {
               IconPoweUp.SetActive(true);
                if (Input.GetMouseButtonDown(1) || Input.GetButton("Xbox_LB"))
                {
                    StartCoroutine(LerpFOV(2f, 4f));
                    MyMovement.GroundSpeed += SpeedIncrease;
                    MyMovement.AirSpeed += AirSpeedIncrease;
                    IconPoweUp.SetActive(false);
                    CanIncrease = false;
                    EmptyIcon.SetActive(true);
                }
            }
           
        }
        if(Faster == false)
        {
            MyMovement.GroundSpeed = CopyGroundSpeed;
            MyMovement.AirSpeed = CopyAirSpeed;
            IconPoweUp.SetActive(false);
            CanIncrease = true;
            EmptyIcon.SetActive(false);
            MyFieldOfView.fieldOfView = 60f;
        }

    }


    IEnumerator LerpFOV(float Duration, float TimeToLerp)
    {
        float TimeC = 0;

        while(TimeC < Duration)
        {
            MyFieldOfView.fieldOfView = Mathf.Lerp(MyFieldOfView.fieldOfView, NewFieldOfView, Time.deltaTime * TimeToLerp);

            TimeC += Time.deltaTime;

            yield return null;
        }
    }
   //IEnumerator LerpReturnFOV(float Duration, float TimeToLerp)
   //{
   //    float TimeC = 0;
   //
   //    while (TimeC < Duration)
   //    {
   //        MyFieldOfView.fieldOfView = Mathf.Lerp(NewFieldOfView, 60f, Time.deltaTime * TimeToLerp);
   //
   //        TimeC += Time.deltaTime;
   //
   //        yield return null;
   //    }
   //}
}
