using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public Transform MeStesso;
    public GameObject Enemy;
    public float Repeating;
    void Start()
    {    
        InvokeRepeating("lateCall", 0f, Repeating);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void lateCall()
    {
        Instantiate(Enemy, MeStesso);
    }
}
