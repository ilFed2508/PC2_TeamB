using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadinToGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadAsynOperation());
    }

    // Update is called once per frame
    IEnumerator LoadAsynOperation()
    {
        yield return new WaitForSeconds(2);
        AsyncOperation gameLevel = SceneManager.LoadSceneAsync(2);
    }
}
