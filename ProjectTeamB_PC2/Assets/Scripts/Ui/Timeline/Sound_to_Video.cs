using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Sound_to_Video : MonoBehaviour
{
    public PlayableDirector Sound_to_VideoSettings;

    void Start()
    {
        Sound_to_VideoSettings = GetComponent<PlayableDirector>();
    }

    public void StartTimeline()
    {
        {
            Sound_to_VideoSettings.Play();
        }
    }
}
