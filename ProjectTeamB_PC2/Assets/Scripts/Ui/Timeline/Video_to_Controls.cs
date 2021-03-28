using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Video_to_Controls : MonoBehaviour
{
    public PlayableDirector Video_to_ControlsSettins;

    void start()
    {
        Video_to_ControlsSettins = GetComponent<PlayableDirector>();
    }

    public void StartTimeline()
    {
        {
            Video_to_ControlsSettins.Play();
        }
    }
}
