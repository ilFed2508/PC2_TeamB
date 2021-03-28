using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Camera_Controls : MonoBehaviour
{
    public PlayableDirector Controls;

    void start()
    {
        Controls = GetComponent<PlayableDirector>();
    }

    public void StartTimeline()
    {
        {
            Controls.Play();
        }
    }
}