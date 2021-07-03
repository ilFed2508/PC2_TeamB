using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnMouseClick_2 : MonoBehaviour
{
    //public GameObject LevelSelectionCanvas, backCanvas;
    //public AudioSource LevelSelectionopen;
    public GodModeUI godModeUI;

    private void OnMouseDown()
    {
        //LevelSelectionCanvas.SetActive(true);
        //backCanvas.SetActive(false);
        //LevelSelectionopen.Play();
        AudioManager.instance.Play("SelectButton");
        godModeUI.ActiveGodmode();
        SceneManager.LoadScene("Loading");
        PlayerPrefs.SetInt("Checkpoint", 2);
    }

    public void OnMouseEnter()
    {
        AudioManager.instance.Play("Interact");
    }
}
