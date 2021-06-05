using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PorcaTroiaProviamo : MonoBehaviour
{
    [HideInInspector]
    public GameObject Player;

    private CameraMovement Test;
    void Start()
    {
        Test = FindObjectOfType<CameraMovement>();
        Player = Test.gameObject;
    }
}
