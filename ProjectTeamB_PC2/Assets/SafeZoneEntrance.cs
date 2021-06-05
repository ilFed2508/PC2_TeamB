using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeZoneEntrance : MonoBehaviour
{
    
    private PowerUpController MyPoweUp;
    public GameObject[] Buttons;



    public void Start()
    {
        MyPoweUp = FindObjectOfType<PowerUpController>();       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            MyPoweUp.DeactivePowerUp();

            for (int i = 0; i < Buttons.Length; i++)
            {
                Buttons[i].SetActive(true);
            }           
        }
    }

    
}
