using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class GamePad_to_Keyboard : MonoBehaviour
{
    public PlayableDirector Pad_to_Keyboard;

    void start()
    {
        Pad_to_Keyboard = GetComponent<PlayableDirector>();
    }

    public void StartTimeline()
    {
        {
            Pad_to_Keyboard.Play();
        }
    }
}
