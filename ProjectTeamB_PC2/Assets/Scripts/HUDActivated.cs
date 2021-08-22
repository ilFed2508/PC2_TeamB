using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDActivated : MonoBehaviour
{
    public GameObject HUD;
    public GameObject MalwarePercentage;
    public GameObject ComboCounter;
    public GameObject OvalMalware;
    public GameObject OvalCombo;
    public GameObject WeaponSlot;
    public GameObject BlackPanel;
    public GameObject MalwareText;
    public GameObject ComboText;


    // Start is called before the first frame update
    void Start()
    {
        MalwarePercentage.SetActive(false);
        ComboCounter.SetActive(false);
        OvalMalware.SetActive(false);
        OvalCombo.SetActive(false);
        BlackPanel.SetActive(false);
        MalwareText.SetActive(false);
        ComboText.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ActiveHUD")
        {
            Time.timeScale = 0;
            WeaponSlot.SetActive(false);
            AudioManager.instance.Play("TutorialUnlocked");
            HUD.SetActive(true);
            BlackPanel.SetActive(true);
            MalwareText.SetActive(true);
            MalwarePercentage.SetActive(true);
            OvalMalware.SetActive(true);
        }

        //if (other.tag == "ActiveHUD" && Input.GetMouseButtonDown(1))
        //{
        //    MalwarePercentage.SetActive(true);
        //    OvalMalware.SetActive(true);
        //}
        //
        //if (other.tag == "ActiveHUD" && Input.GetMouseButtonDown(1) && MalwarePercentage.activeInHierarchy)
        //{
        //    OvalMalware.SetActive(false);
        //    ComboCounter.SetActive(true);
        //    OvalCombo.SetActive(true);
        //}

        //else
        //OvalMalware.SetActive(true);
        //ComboCounter.SetActive(false);
        //OvalCombo.SetActive(false);
    }

    private void Update()
    {
        //if (HUD.activeInHierarchy && Input.GetMouseButtonDown(1))
        //{
        //    MalwarePercentage.SetActive(true);
        //    OvalMalware.SetActive(true);
        //}

        if (Input.GetMouseButtonDown(1) && HUD.activeInHierarchy && MalwarePercentage.activeInHierarchy && OvalMalware.activeInHierarchy)
        {
            OvalMalware.SetActive(false);
            MalwareText.SetActive(false);
            AudioManager.instance.Play("TutorialUnlocked");
            ComboText.SetActive(true);
            ComboCounter.SetActive(true);
            OvalCombo.SetActive(true);
        }

        if (Input.GetMouseButtonDown(0) && HUD.activeInHierarchy && ComboCounter.activeInHierarchy && OvalCombo.activeInHierarchy)
        {
            Destroy(OvalCombo);
            Destroy(OvalMalware);
            Destroy(BlackPanel);
            WeaponSlot.SetActive(true);
            Time.timeScale = 1;
        }
    }
}
