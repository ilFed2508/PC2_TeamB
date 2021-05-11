using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestTest : MonoBehaviour {

    public Text timerText;
    public static int scoreTime;
    public static string username;
    public InputField iField;

    private float startTime;
    private bool finished = false;

    public GameObject scriptRef;


    // Start is called before the first frame update
    void Start() {
        startTime = Time.time + 5;
    }

    // Update is called once per frame
    /*
    void Update() {
        if (finished)
            return;

        float t = Time.time - startTime;
        scoreTime = (int)t;

        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f2");

        timerText.text = minutes + ":" + seconds;

        //Debug.Log(FormatTime(t));
        Debug.Log(scoreTime);
    }
    */

    public void Finish() {

        finished = true;
        timerText.color = Color.black;

    }

    string FormatTime(float time) {
        int intTime = (int)time;
        int minutes = intTime / 60;
        int seconds = intTime % 60;
        float fraction = time * 1000;
        fraction = (fraction % 1000);
        string timeText = System.String.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, fraction);
        return timeText;
    }

    public void LeaderboardButton(string user) {
        AddNewHighscore(user, scoreTime);
        DownloadHighscores();
    }

    #region SETTING HIGHSCORES

    const string privateCode = "qQO33u6slEKTdGtSXW1f0Q977ntazbZUi2fKiOtDi7Rg";
    const string publicCode = "609a616b8f40c30ca04ab380";
    const string webURL = "http://dreamlo.com/lb/";

    public static int time = 150000;
    public static string user;

    public void AddNewHighscore(string username, int scoreTime) {
        StartCoroutine(UploadNewHighscore(username, scoreTime));
    }

    IEnumerator UploadNewHighscore(string username, int scoreTime) {

        time = scoreTime;
        user = username;
        //username = Timer.username;

        WWW www = new WWW(webURL + privateCode + "/add/" + WWW.EscapeURL(user) + "/" + time);
        yield return www;

        if (string.IsNullOrEmpty(www.error))
            print("Upload Successfull");
        else {
            print("Error uploading: " + www.error);
        }
    }
    #endregion

    #region DOWNLOADING HIGHSCORES



    public void DownloadHighscores() {
        StartCoroutine("DownloadingScoresFromDB");
    }

    IEnumerator DownloadingScoresFromDB() {

        yield return new WaitForSeconds(2f);

        WWW www = new WWW(webURL + publicCode + "/pipe/");
        yield return www;

        if (string.IsNullOrEmpty(www.error))
            print(www.text);
        else {
            print("Error downloading: " + www.error);
        }
    }

    #endregion

}
