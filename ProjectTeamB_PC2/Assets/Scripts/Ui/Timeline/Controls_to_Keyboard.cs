using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Controls_to_Keyboard : MonoBehaviour
{
    public PlayableDirector Controls_to_KeyMouse;

    void start()
    {
        Controls_to_KeyMouse = GetComponent<PlayableDirector>();
    }

    public void StartTimeline()
    {
        {
            Controls_to_KeyMouse.Play();
        }
    }
}
