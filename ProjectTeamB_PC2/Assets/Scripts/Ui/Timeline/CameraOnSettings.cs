using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CameraOnSettings : MonoBehaviour
{
    public PlayableDirector SetingsTimeline;

    void start()
    {
        SetingsTimeline = GetComponent<PlayableDirector>();
    }

    public void StartTimeline()
    {
        {
            SetingsTimeline.Play();
        }
    }
}
