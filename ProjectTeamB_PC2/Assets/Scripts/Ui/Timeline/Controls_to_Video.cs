using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Controls_to_Video : MonoBehaviour
{
    public PlayableDirector Controls_to_VideoSettings;

    void start()
    {
        Controls_to_VideoSettings = GetComponent<PlayableDirector>();
    }

    public void StartTimeline()
    {
        {
            Controls_to_VideoSettings.Play();
        }
    }
}
