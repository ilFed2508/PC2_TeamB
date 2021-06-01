using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PorcaTroiaProviamo : MonoBehaviour
{
    [HideInInspector]
    public GameObject Player;

    private PlayerController Test;
    void Start()
    {
        Test = FindObjectOfType<PlayerController>();
        Player = Test.Player;
    }
}
