using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateMuzzle : MonoBehaviour
{
    public ParticleSystem particlePrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            particlePrefab.Play();
        }
    }
}
