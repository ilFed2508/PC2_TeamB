using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Keyboard_to_Controls : MonoBehaviour
{
    public PlayableDirector KeyMouse_to_Controls;

    void start()
    {
        KeyMouse_to_Controls = GetComponent<PlayableDirector>();
    }

    public void StartTimeline()
    {
        {
            KeyMouse_to_Controls.Play();
        }
    }
}
