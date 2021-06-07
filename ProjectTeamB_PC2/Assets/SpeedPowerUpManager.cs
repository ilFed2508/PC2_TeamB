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

    public bool Faster;


    // Start is called before the first frame update
    void Start()
    {
        MyMovement = FindObjectOfType<PlayerMovement>();
        CopyAirSpeed = MyMovement.AirSpeed;
        CopyGroundSpeed = MyMovement.GroundSpeed;
        Faster = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Faster == true )
        {
          CanIncrease = true;
            if (CanIncrease == true)
            {
                if(Input.GetMouseButtonDown(1) || Input.GetButton("Xbox_LB"))
                {
                    MyMovement.GroundSpeed += SpeedIncrease;
                    MyMovement.AirSpeed += AirSpeedIncrease;
                    CanIncrease = false;
                }       
            }
           
        }
        if(Faster == false)
        {
            MyMovement.GroundSpeed = CopyGroundSpeed;
            MyMovement.AirSpeed = CopyAirSpeed;
            CanIncrease = true;
        }
    }
}
