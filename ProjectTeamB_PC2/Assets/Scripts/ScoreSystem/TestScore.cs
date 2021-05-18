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
            TestScoreController.AddScore(1);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            TestScoreController.RemoveScore(2);
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            TestScoreController.SetScore(100);
        }
    }
}
