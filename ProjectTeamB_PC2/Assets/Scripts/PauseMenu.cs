using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseMenuPanel;
    public GameObject HUD, CrossHair, EPickUp;
    public PlayerController playerController;
    public bool IsStopped;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponentInParent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsStopped == false)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Time.timeScale = 0;
                PauseMenuPanel.SetActive(true);
                IsStopped = true;

                HUD.SetActive(false);
                CrossHair.SetActive(false);
                EPickUp.SetActive(false);               
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

        HUD.SetActive(true);
        CrossHair.SetActive(true);
    }
    public void BackToMenu()
    {
        Time.timeScale = 1;
        PlayerPrefs.SetInt("TotalScore", 0);
        SceneManager.LoadScene("3DMenuTestP");
    }

    public void Reload()
    {
        Time.timeScale = 1;
        PlayerPrefs.SetInt("TotalScore", playerController.playerScore.GetTotalScore());
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
