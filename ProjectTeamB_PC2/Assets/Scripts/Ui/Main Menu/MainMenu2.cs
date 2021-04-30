using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu2 : MonoBehaviour
{
    public GameObject Settings, Sound, Controls, Video, PauseMenu, Gamepad, KeyBoard;
    //public GameObject Opening, Credits, MainMenu, Exit, Play;
    Settings settings;
    public bool isOpening;
    // Start is called before the first frame update
    void Start()
    {
        settings = FindObjectOfType<Settings>();
    }

    // Update is called once per frame
    void Update()
    {
        AnyKey();
    }

    public void AnyKey()
    {
        if(Input.anyKeyDown&&isOpening==true)
        {
            //Opening.SetActive(false);
            //MainMenu.SetActive(true);
            isOpening = false;
        }
    }

    public void GoToSettings()
    {
        //MainMenu.SetActive(false);
        Settings.SetActive(true);
        PauseMenu.SetActive(false);
        GoToSound();
    }
    public void GoToCredits()
    {
        //MainMenu.SetActive(false);
        //Credits.SetActive(true);
    }
    public void GoToExit()
    {
        //MainMenu.SetActive(false);
        //Exit.SetActive(true);
    }
    public void GoToPlay()
    {
        //MainMenu.SetActive(false);
        //Play.SetActive(true);
    }
    public void BackToMenu()
    {
        Settings.SetActive(false);
        //Credits.SetActive(false);
        //Exit.SetActive(false);
        //Play.SetActive(false);
        //MainMenu.SetActive(true);
    }

    public void BacktoPause()
    {
        Settings.SetActive(false);
        PauseMenu.SetActive(true);
    }

    public void GoToSound()
    {
        Sound.SetActive(true);
        Controls.SetActive(false);
        Video.SetActive(false);
    }
    public void GoToControls()
    {
        Sound.SetActive(false);
        Controls.SetActive(true);
        Video.SetActive(false);
    }
    public void GoToVideo()
    {
        Sound.SetActive(false);
        Controls.SetActive(false);
        Video.SetActive(true);
    }

    public void BackToControls()
    {
        Sound.SetActive(false);
        Controls.SetActive(true);
        Video.SetActive(false);
        KeyBoard.SetActive(false);
        Gamepad.SetActive(false);
    }

    public void GoToKeyBoard()
    {
        Sound.SetActive(false);
        Controls.SetActive(false);
        Video.SetActive(false);
        KeyBoard.SetActive(true);
        Gamepad.SetActive(false);
    }

    public void GoToGamePad()
    {
        Sound.SetActive(false);
        Controls.SetActive(false);
        Video.SetActive(false);
        KeyBoard.SetActive(false);
        Gamepad.SetActive(true);     
    }

    public void CloseGame()
    {
        Application.Quit();
        Debug.Log("Game Closed");
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
