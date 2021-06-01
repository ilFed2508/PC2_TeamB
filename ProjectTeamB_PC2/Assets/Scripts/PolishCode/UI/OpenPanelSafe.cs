using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPanelSafe : MonoBehaviour
{

    public GameObject SafePanel, HUD,WeaponSlot;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Open"))
        {
            SafePanel.SetActive(true);
            HUD.SetActive(false);
            WeaponSlot.SetActive(false);           
            StartCoroutine(MyCoroutine());
        }
    }

    // Update is called once per frame
    IEnumerator MyCoroutine()
    {
        yield return new WaitForSeconds(1.0f);
        SafePanel.SetActive(false);
        WeaponSlot.SetActive(true);
        HUD.SetActive(true);        
    }
}
