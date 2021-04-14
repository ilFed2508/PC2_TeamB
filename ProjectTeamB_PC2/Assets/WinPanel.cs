using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinPanel : MonoBehaviour
{
    private EnemiesTrigger WinDoor;
    public GameObject Winpanel, LifeBar, WeaponIcon, AmmoCounter, Combo, Warning;
    void Start()
    {
        WinDoor = GameObject.Find("EndDoor").GetComponent<EnemiesTrigger>();
        WinDoor.end = Winpanel;

        LifeBar.SetActive(true);
        WeaponIcon.SetActive(true);
        AmmoCounter.SetActive(true);
        Combo.SetActive(true);
        Warning.SetActive(true);
    }
}
