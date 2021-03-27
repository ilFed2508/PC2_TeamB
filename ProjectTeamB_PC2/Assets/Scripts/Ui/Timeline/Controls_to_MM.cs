using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Controls_to_MM : MonoBehaviour
{
    public PlayableDirector Controls_to_Main;

    void start()
    {
        Controls_to_Main = GetComponent<PlayableDirector>();
    }

    public void StartTimeline()
    {
        {
            Controls_to_Main.Play();
        }
    }
}
