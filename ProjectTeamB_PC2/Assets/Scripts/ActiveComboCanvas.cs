using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveComboCanvas : MonoBehaviour
{
    
    private PlayerController canvasCombo;
    private PauseMenu PM;
    // Start is called before the first frame update
    void Start()
    {
        canvasCombo = FindObjectOfType<PlayerController>();
        PM = FindObjectOfType<PauseMenu>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            canvasCombo.CanvasCombo.SetActive(true);
            PM.IsInTutorial = false;
        }
    }
}
