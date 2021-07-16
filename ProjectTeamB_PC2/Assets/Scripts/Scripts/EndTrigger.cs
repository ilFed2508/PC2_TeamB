using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    private GameObject EndMenu;

    private void Start()
    {
        EndMenu = GameObject.Find("WIN_FinalRoom");
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Time.timeScale = 0f;
            EndMenu.SetActive(true);
        }
    }
}
