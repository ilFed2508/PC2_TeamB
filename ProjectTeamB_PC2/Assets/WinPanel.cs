using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinPanel : MonoBehaviour
{
    private EnemiesTrigger WinDoor;
    public GameObject Winpanel;

    public GameObject hud;
    void Start()
    {
        WinDoor = GameObject.Find("EndDoor").GetComponent<EnemiesTrigger>();
        WinDoor.end = Winpanel;
        WinDoor.HUD = hud;
    }
}
