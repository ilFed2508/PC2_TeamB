using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerLevelSelection : MonoBehaviour
{
    public GameObject levelselectionCanvas;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && Input.GetKey(KeyCode.E))
        {
            levelselectionCanvas.SetActive(true);
        }
    }
}
