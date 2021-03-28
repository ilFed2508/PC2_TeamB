using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class GamePad_to_Controls : MonoBehaviour
{
    public PlayableDirector Pad_to_Controls;

    void start()
    {
        Pad_to_Controls = GetComponent<PlayableDirector>();
    }

    public void StartTimeline()
    {
        {
            Pad_to_Controls.Play();
        }
    }
}
