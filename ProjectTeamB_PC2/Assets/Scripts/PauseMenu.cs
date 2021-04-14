﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseMenuPanel;
    public GameObject LifeBar, WeaponIcon, AmmoCounter, Combo;

    public bool IsStopped;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsStopped == false)
            {
                Time.timeScale = 0;
                PauseMenuPanel.SetActive(true);
                IsStopped = true;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;

                LifeBar.SetActive(false);
                WeaponIcon.SetActive(false);
                AmmoCounter.SetActive(false);
                Combo.SetActive(false);
            }
            else
            {
                ResumeGame();
            }
        }
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        PauseMenuPanel.SetActive(false);
        IsStopped = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        LifeBar.SetActive(true);
        WeaponIcon.SetActive(true);
        AmmoCounter.SetActive(true);
        Combo.SetActive(true);
    }
    public void BackToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("3DMenuTestP");
    }

    public void Reload()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //aggiunta bottone quit game - Joe
    public void Exit()
    {
        Application.Quit();
    }

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

}
