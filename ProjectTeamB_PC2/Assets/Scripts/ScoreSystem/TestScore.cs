using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScore : MonoBehaviour
{
    private ScoreController TestScoreController;

    // Start is called before the first frame update
    void Start()
    {
        TestScoreController = GetComponent<ScoreController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            int totalScore = PlayerPrefs.GetInt("PlayerTotalScore");
            Debug.Log(PlayerPrefs.GetInt("PlayerTotalScore"));
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            PlayerPrefs.SetInt("PlayerHighScore", 0);
            PlayerPrefs.Save();
            Debug.Log(PlayerPrefs.GetInt("PlayerHighScore"));
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            Debug.Log(PlayerPrefs.GetString("PlayerName"));
        }
    }
}
