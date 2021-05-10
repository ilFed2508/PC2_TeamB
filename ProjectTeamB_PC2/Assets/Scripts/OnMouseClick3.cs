using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnMouseClick3 : MonoBehaviour
{
    //public GameObject LevelSelectionCanvas, backCanvas;
    //public AudioSource LevelSelectionopen;

    private void OnMouseDown()
    {
        //LevelSelectionCanvas.SetActive(true);
        //backCanvas.SetActive(false);
        //LevelSelectionopen.Play();
        SceneManager.LoadScene("Loading");
        PlayerPrefs.SetInt("Checkpoint", 1);
    }
}