using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Video_to_MM : MonoBehaviour
{
    public PlayableDirector Video_to_MainMenu;

    void start()
    {
        Video_to_MainMenu = GetComponent<PlayableDirector>();
    }

    public void StartTimeline()
    {
        {
            Video_to_MainMenu.Play();
        }
    }
}
