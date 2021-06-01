using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnMouseClick_4 : MonoBehaviour
{
    //public GameObject LevelSelectionCanvas, backCanvas;
    //public AudioSource LevelSelectionopen;
    public GodModeUI godModeUI;

    private void OnMouseDown()
    {
        //LevelSelectionCanvas.SetActive(true);
        //backCanvas.SetActive(false);
        //LevelSelectionopen.Play();
        godModeUI.ActiveGodmode();
        SceneManager.LoadScene("Loading");
        PlayerPrefs.SetInt("Checkpoint", 4);
    }
}
