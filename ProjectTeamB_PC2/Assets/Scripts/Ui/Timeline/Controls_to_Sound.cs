using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Controls_to_Sound : MonoBehaviour
{
    public PlayableDirector Controls_to_settingsSound;

    void start()
    {
        Controls_to_settingsSound = GetComponent<PlayableDirector>();
    }

    public void StartTimeline()
    {
        {
            Controls_to_settingsSound.Play();
        }
    }
}
