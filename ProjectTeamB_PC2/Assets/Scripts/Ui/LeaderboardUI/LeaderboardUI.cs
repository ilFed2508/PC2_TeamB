using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardUI : MonoBehaviour
{
    public GameObject LeaderboardMenuUI, WinMenuUI; 

    public void ActiveLeaderboardMenu()
    {
        if(LeaderboardMenuUI != null && WinMenuUI != null)
        {
            LeaderboardMenuUI.SetActive(true);
            WinMenuUI.SetActive(false);
        }        
    }

    public void DeactiveLeaderboardMenu()
    {
        if (LeaderboardMenuUI != null && WinMenuUI != null)
        {
            LeaderboardMenuUI.SetActive(false);
            WinMenuUI.SetActive(true);
        }
    }
}
