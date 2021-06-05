using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSlideButtonFALSE : MonoBehaviour
{

    private PowerUpController MyPowerUp;

    void Start()
    {
        MyPowerUp = FindObjectOfType<PowerUpController>();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            MyPowerUp.DeactivePowerUp();
        }
    }

}
