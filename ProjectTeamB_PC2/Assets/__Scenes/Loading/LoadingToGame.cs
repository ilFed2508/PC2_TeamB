using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingToGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadAsynOperation());
    }

    // Update is called once per frame
    IEnumerator LoadAsynOperation()
    {
        yield return new WaitForSeconds(3);
        AsyncOperation gameLevel = SceneManager.LoadSceneAsync(3);
    }
}
