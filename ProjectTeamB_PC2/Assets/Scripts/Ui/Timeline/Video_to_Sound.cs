using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Video_to_Sound : MonoBehaviour
{
    public PlayableDirector Video_to_SoundSettins;

    void start()
    {
        Video_to_SoundSettins = GetComponent<PlayableDirector>();
    }

    public void StartTimeline()
    {
        {
            Video_to_SoundSettins.Play();
        }
    }
}