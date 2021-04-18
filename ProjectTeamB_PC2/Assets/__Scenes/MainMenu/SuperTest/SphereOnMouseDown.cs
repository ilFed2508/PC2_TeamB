using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereOnMouseDown : MonoBehaviour
{
    public GameObject LevelSelectionCanvas, backCanvas;
    public AudioSource LevelSelectionopen;

    private void Start()
    {
    }

    private void OnMouseDown()
    {
        LevelSelectionCanvas.SetActive(true);
        backCanvas.SetActive(false);
        LevelSelectionopen.Play();
    }
}
