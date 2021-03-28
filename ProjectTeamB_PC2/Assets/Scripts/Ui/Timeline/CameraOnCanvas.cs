using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CameraOnCanvas : MonoBehaviour
{
    public PlayableDirector timeline;

    void start()
    {
        timeline = GetComponent<PlayableDirector>();
    }

public void StartTimeline()
    {
        {
            timeline.Play();
        }
    }
}
