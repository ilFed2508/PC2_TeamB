using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverScripts : MonoBehaviour
{
    public GameObject panelDescription;

    private void Start()
    {
        panelDescription.SetActive(false);
    }

    public void OnMouseEnter()
    {
        panelDescription.SetActive(true);
        AudioManager.instance.Play("Interact");
    }

    public void OnMouseExit()
    {
        panelDescription.SetActive(false);
    }
}
