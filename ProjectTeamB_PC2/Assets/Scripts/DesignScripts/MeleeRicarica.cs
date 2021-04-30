using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeRicarica : MonoBehaviour
{
    public float timerPerMelee;
    public float timerRicaricaMelee;
    private Animator anim;
    public string animazione = "Melee";
    private PlayerController playerController;
    private bool possoColpire;


    public void Start()
    {
        anim = GetComponent<Animator>();
        playerController = FindObjectOfType<PlayerController>();
        
        
    }
    public void Update()
    {
        if(timerPerMelee > 0)
        {
            timerPerMelee -= Time.deltaTime;
        }
        if(timerPerMelee <= 0)
        {
            timerPerMelee = Time.deltaTime;
            possoColpire = true;
        }
       
        
        if (Input.GetKeyDown(KeyCode.R) && possoColpire)
        {
            playerController.Melee.gameObject.SetActive(true);
            timerPerMelee = timerRicaricaMelee;
            possoColpire = false;
            anim.SetBool(animazione, true);

        }
        else
        {
            playerController.Melee.gameObject.SetActive(false);
            anim.SetBool(animazione, false);
        }

        Debug.Log("manca" + Mathf.Round(timerPerMelee));
    }
}
