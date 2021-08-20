using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RedCrosshair : MonoBehaviour
{
    public Image crosshair;

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 1f));
        RaycastHit Hit;

        if (Physics.Raycast(ray, out Hit) && Hit.collider.CompareTag("Enemy"))
        {
            crosshair.color = Color.red;
        }
        else
        {
            crosshair.color = Color.white;
        }
    }
}
