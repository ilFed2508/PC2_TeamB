using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class katanaHover : MonoBehaviour
{
    public GameObject panelDescription;

    private void Start()
    {
        panelDescription.SetActive(false);
    }

    public void OnMouseEnter()
    {
        panelDescription.SetActive(true);
    }

    public void OnMouseExit()
    {
        panelDescription.SetActive(false);
    }
}

