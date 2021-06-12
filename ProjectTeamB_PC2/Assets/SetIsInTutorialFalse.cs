using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetIsInTutorialFalse : MonoBehaviour
{

    private PauseMenu MyMenù;
    // Start is called before the first frame update
    void Start()
    {
        MyMenù = FindObjectOfType<PauseMenu>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            MyMenù.IsInTutorial = false;
        }
    }
}
