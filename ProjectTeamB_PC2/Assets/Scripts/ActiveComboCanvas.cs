using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveComboCanvas : MonoBehaviour
{
    
    private PlayerController canvasCombo;
    // Start is called before the first frame update
    void Start()
    {
        canvasCombo = FindObjectOfType<PlayerController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            canvasCombo.CanvasCombo.SetActive(true);
        }
    }
}
