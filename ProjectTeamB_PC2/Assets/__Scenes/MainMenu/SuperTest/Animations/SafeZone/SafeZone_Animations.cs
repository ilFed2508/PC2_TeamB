using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeZone_Animations : MonoBehaviour
{
    public Animator cameraSafe;

    public void PowerUp()
    {
        cameraSafe.SetInteger("Page", 0);
    }

    public void Leaderboard()
    {
        cameraSafe.SetInteger("Page", 1);
    }
}
