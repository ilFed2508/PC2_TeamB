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
    public GameObject ContinueLife_Tutorial;
    public GameObject MouseRight;
    public GameObject MouseLeft;
    public GameObject ContinueCombo_Tutorial;


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
        MouseRight.SetActive(false);
        ContinueLife_Tutorial.SetActive(false);
        MouseLeft.SetActive(false);
        ContinueCombo_Tutorial.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ActiveHUD")
        {
            Time.timeScale = 0;
            WeaponSlot.SetActive(false);
            HUD.SetActive(true);
            BlackPanel.SetActive(true);
            MalwarePercentage.SetActive(true);
            StartCoroutine(TutorialLife());
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

    IEnumerator TutorialLife()
    {
        yield return new WaitForSecondsRealtime(0.8f);
        AudioManager.instance.Play("TutorialUnlocked");
        OvalMalware.SetActive(true);
        yield return new WaitForSecondsRealtime(0.8f);
        MalwareText.SetActive(true);
        yield return new WaitForSecondsRealtime(2f);
        ContinueLife_Tutorial.SetActive(true);
        MouseRight.SetActive(true);
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
            Destroy(OvalMalware);
            Destroy(MalwareText);
            ComboCounter.SetActive(true);
            StartCoroutine(TutorialCombo());
            //AudioManager.instance.Play("TutorialUnlocked");
            //ComboText.SetActive(true);
            //OvalCombo.SetActive(true);
        }

        if (Input.GetMouseButtonDown(0) && HUD.activeInHierarchy && ComboCounter.activeInHierarchy && OvalCombo.activeInHierarchy)
        {
            Destroy(BlackPanel);
            Destroy(OvalCombo);
            WeaponSlot.SetActive(true);
            Time.timeScale = 1;
        }
    }

    IEnumerator TutorialCombo()
    {
        yield return new WaitForSecondsRealtime(0.8f);
        AudioManager.instance.Play("TutorialUnlocked");
        OvalCombo.SetActive(true);
        yield return new WaitForSecondsRealtime(0.8f);
        ComboText.SetActive(true);
        yield return new WaitForSecondsRealtime(2f);
        ContinueCombo_Tutorial.SetActive(true);
        MouseLeft.SetActive(true);
    }
}
