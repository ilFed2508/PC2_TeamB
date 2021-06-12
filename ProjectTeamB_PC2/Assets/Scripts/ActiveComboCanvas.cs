using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveComboCanvas : MonoBehaviour
{
    
    private PlayerController canvasCombo;
    private PauseMenu MyMenù;
    // Start is called before the first frame update
    void Start()
    {
        MyMenù = FindObjectOfType<PauseMenu>();
        canvasCombo = FindObjectOfType<PlayerController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            MyMenù.IsInTutorial = false;
            canvasCombo.CanvasCombo.SetActive(true);
        }
    }
}
