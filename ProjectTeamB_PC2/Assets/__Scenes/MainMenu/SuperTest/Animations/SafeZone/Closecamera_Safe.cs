using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Closecamera_Safe : MonoBehaviour
{
    public GameObject cameraSafe, PowerUpCanvas, Emote;

    private PorcaTroiaProviamo Player;
    public void Start()
    {
        Player = GameObject.Find("QuellaTroia").GetComponent<PorcaTroiaProviamo>();
    }

    public void CloseCamera()
    {
        Player.Player.SetActive(true);
        Emote.SetActive(true);
        cameraSafe.SetActive(false);
        PowerUpCanvas.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
