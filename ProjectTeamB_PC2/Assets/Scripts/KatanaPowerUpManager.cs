using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KatanaPowerUpManager : MonoBehaviour
{
    public GameObject WeaponToSpawn;
    public GameObject SecondWeaponToSpawn;

    public GameObject KatanaContenitore;

    public bool CanUseKatana;
    private bool IconIsActive;

    public GameObject KatanaIcon;
    public bool CanSwitchKatana;

    

    void Start()
    {
        CanUseKatana = false;
        IconIsActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(CanUseKatana == true)
        {
            if (IconIsActive == true)
            {
                KatanaIcon.SetActive(true);
                if (Input.GetMouseButtonDown(1) || Input.GetButton("Xbox_LB"))
                {
                    KatanaContenitore.SetActive(true);
                    KatanaIcon.SetActive(false);
                    IconIsActive = false;

                }
            }

        }

       if(CanUseKatana == false)
       {
            KatanaIcon.SetActive(false);
            IconIsActive = true;
            KatanaContenitore.SetActive(false);
       }
    }


}
