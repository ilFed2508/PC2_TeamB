using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Keyboard_to_GamePad : MonoBehaviour
{
    public PlayableDirector KeyMouse_to_Pad;

    void start()
    {
        KeyMouse_to_Pad = GetComponent<PlayableDirector>();
    }

    public void StartTimeline()
    {
        {
            KeyMouse_to_Pad.Play();
        }
    }
}
