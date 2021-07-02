using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
public class PPAcces : MonoBehaviour
{


    public Volume miovolume;

    public Bloom myBloom;

    // Start is called before the first frame update
    void Start()
    {
       miovolume.profile.TryGet(out myBloom);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.L))
        {
            myBloom.intensity.value = 10f;
        }
    }
}
