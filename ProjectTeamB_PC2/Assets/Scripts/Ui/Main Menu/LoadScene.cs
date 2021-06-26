using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void LoadScene_(string scene)
    {
        SceneManager.LoadScene(scene);

        PlayerPrefs.SetInt("Checkpoint", 1);
    }
}
