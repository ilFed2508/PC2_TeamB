using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleePercentuale : MonoBehaviour
{
    
    
    private Animator WeaponSlot;
    private Animator Melee;
    public CameraShake.Properties testProperties;
    public string Suono;

    public float TimerForMelee;
    public float CopyTimerForMelee;
    private bool PossoMenare;

    public void Start()
    {
        PossoMenare = true;
        WeaponSlot = GameObject.Find("WeaponSlot").GetComponent<Animator>();
        Melee = GameObject.Find("Mecha_arm_sx_rigged(Pugno)").GetComponent<Animator>();
    }
    public void Update()
    {
        if(TimerForMelee > 0)
        {
           TimerForMelee -= Time.deltaTime;
        }
        
        if(TimerForMelee <= 0)
        {
            PossoMenare = true;
        }

        if ((Input.GetKeyDown(KeyCode.Q) || Input.GetButtonDown("Xbox_B")) && PossoMenare)
        {            
            Melee.Play("Melee");
            WeaponSlot.Play("Melee-WeaponSlot");
            AudioManager.instance.Play(Suono);          
            FindObjectOfType<CameraShake>().StartShake(testProperties);
            TimerForMelee = CopyTimerForMelee;
            PossoMenare = false;
        }
        
    }       
}
