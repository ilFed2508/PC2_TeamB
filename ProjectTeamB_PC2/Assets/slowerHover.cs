using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slowerHover : MonoBehaviour
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

