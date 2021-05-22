using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddHighscore : MonoBehaviour
{

    public InputField myField;
    

    public void AddingScore(string username) 
    {
        username = myField.text;

        Highscores.AddNewHighscore(username, 150000);
    }

}
