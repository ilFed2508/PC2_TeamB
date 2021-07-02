using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundHover : MonoBehaviour
{
    public void SoundHover_()
    {
        AudioManager.instance.Play("Interact");
    }
}
