using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddHighscore : MonoBehaviour
{

    public InputField myField;
    private string user;

    public void AddingScore(string username) {

        user = myField.text;
        username = user;

        Highscores.AddNewHighscore(username, 150000);

    }

}
