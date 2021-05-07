using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Closecamera_Safe : MonoBehaviour
{
    public GameObject cameraSafe;
    private GameObject Player;

    public void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    public void CloseCamera()
    {
        //cameraSafe.SetActive(false);
        Player.SetActive(true);
    }
}
