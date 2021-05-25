using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestDeathPanelBug : MonoBehaviour
{
    public void BackToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("3DMenuTestP");
    }
}
