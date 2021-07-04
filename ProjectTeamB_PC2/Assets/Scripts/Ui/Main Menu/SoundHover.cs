using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundHover : MonoBehaviour
{
    public void SoundHover_()
    {
        AudioManager.instance.Play("Interact");
    }

    public void DeniedButton_()
    {
        AudioManager.instance.Play("DeniedButton");
    }

    public void SelectButton_()
    {
        AudioManager.instance.Play("SelectButton");
    }

    public void PCInteractOFF_()
    {
        AudioManager.instance.Play("PCInteractOFF");
    }
}
