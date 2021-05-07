using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSoundMiniGun : MonoBehaviour
{
    public string Suono;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            AudioManager.instance.Play(Suono);
        }
        else
        {
            AudioManager.instance.Stop(Suono);
        }
    }
}
