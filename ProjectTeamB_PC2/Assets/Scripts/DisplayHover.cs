using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DisplayHover : MonoBehaviour
{
    public GameObject leaderboard, Emote;

    private void Start()
    {
        leaderboard.SetActive(false);
        Emote.SetActive(true);
    }

    public void OnMouseEnter()
    {
        leaderboard.SetActive(true);
        Emote.SetActive(false);
    }

    public void OnMouseExit()
    {
        leaderboard.SetActive(false);
        Emote.SetActive(true);
    }
}

