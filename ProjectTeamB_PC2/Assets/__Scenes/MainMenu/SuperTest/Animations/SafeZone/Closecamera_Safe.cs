using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Closecamera_Safe : MonoBehaviour
{
    public GameObject cameraSafe, PowerUpCanvas, Emote, Particle;

    private PorcaTroiaProviamo Player;
    public void Start()
    {
        Player = GameObject.Find("QuellaTroia").GetComponent<PorcaTroiaProviamo>();
    }

    public void CloseCamera()
    {
        Player.Player.SetActive(true);
        Emote.SetActive(true);
        Particle.SetActive(false);
        cameraSafe.SetActive(false);
        PowerUpCanvas.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
