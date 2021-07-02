using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchPowerLeadet : MonoBehaviour
{
    public GameObject PowerUP, Leaderboard;

    public void powerUP()
    {
        Leaderboard.SetActive(false);
        PowerUP.SetActive(true);
    }

    public void leaderBoard()
    {
        PowerUP.SetActive(false);
        Leaderboard.SetActive(true);
    }
}
