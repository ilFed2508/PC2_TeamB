using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinPanel : MonoBehaviour
{
    private EnemiesTrigger WinDoor;
    public GameObject Winpanel;
    void Start()
    {
        WinDoor = GameObject.Find("EndDoor").GetComponent<EnemiesTrigger>();
        WinDoor.end = Winpanel;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
