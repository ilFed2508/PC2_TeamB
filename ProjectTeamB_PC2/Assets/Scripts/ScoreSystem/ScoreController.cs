using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    [SerializeField]
    private ScoreDatabase Database;
    //[SerializeField]
    //private int StartingScore;
    [SerializeField]
    private int CurrentScore;
    [SerializeField]
    private int TotalScore;
    [HideInInspector]
    private int HighScore;
    [HideInInspector]
    public int CostScore;



    //text momentaneo
    public Text CurrentScoreText, AddText,FinalScore,FinalScoreLeaderboard;
    public GameObject AddScoreObj;

    // Start is called before the first frame update
    void Start()
    {
        Initialize();   
    }

    private void Update()
    {       
        CostScore = CurrentScore;
        CurrentScoreText.text = CostScore.ToString();
        FinalScore.text = "YOUR SCORE - " + TotalScore;
        FinalScoreLeaderboard.text = "YOUR SCORE - " + TotalScore;
    }

    #region BehaviourAPI

    public void Initialize()
    {
        //set Current score = 0 and save totalScore if doesnt exist also highscore
        CurrentScore = 0;
        if (PlayerPrefs.HasKey("PlayerTotalScore") == false)
        {
            TotalScore = 0;
            PlayerPrefs.SetInt("PlayerTotalScore", TotalScore);
        }
        if (PlayerPrefs.HasKey("PlayerHighScore") == false)
        {
            HighScore = 0;
            PlayerPrefs.SetInt("PlayerHighScore", HighScore);
        }

        //controllo variabili
        if (Database == null)
        {
            Debug.LogError("Non hai messo la referenza al database nello ScoreController!");
        }
        else
        {
            //controllo database corretto
            for (int i = 1; i < 13; i++)
            {
                int ActionCounter = Database.ScoreRecipes.Count(act => (int)act.Action == i);

                if(ActionCounter > 1)
                {
                    Debug.LogWarning("Attento hai 2 azioni uguali nello scriptable ScoreDatabase!");
                }
            }
        }

        if(CurrentScoreText == null)
        {
            Debug.LogError("Non hai messo la referenza allo score text nello ScoreController!");
        }
       
    }

    public void AddScore(int ActionID)
    {
        CurrentScore += GetActionValue(ActionID);
        AddScoreObj.SetActive(true);
        AddText.text = "+" + GetActionValue(ActionID).ToString();
    }

    public void AddValueScore(int value)
    {
        CurrentScore += value;
    }

    public void AddTotalScore(int value)
    {
        TotalScore += value;
    }

    public void RemoveScore(int ActionID)
    {
        CurrentScore -= GetActionValue(ActionID);

        if(CurrentScore < 0)
        {
            CurrentScore = 0;
        }
    }
    public void PurchasePowerUp(int Cost)
    {
        CostScore -= Cost;

        if (CurrentScore < 0)
        {
            CurrentScore = 0;
        }
    }

    public void SetScore(int value)
    {
        CurrentScore = value;
    }

    public void SetTotalScore(int value)
    {
        TotalScore = value;
    }

    public void AddHighScoreToLeaderboard()
    {
        Highscores.AddNewHighscore(PlayerPrefs.GetString("PlayerName"), PlayerPrefs.GetInt("PlayerHighScore"));
    }
    #endregion

    #region DebugAPI

    public ScoreDatabase GetDatabase() => Database;

    public int GetHighScore() => HighScore;

    public int GetCurrentScore() => CurrentScore;

    public int GetTotalScore() => TotalScore;

    public ScoreAction GetAction(ScoreRecipe recipe) => recipe.Action;

    public int GetActionValue(ScoreAction Action)
    {
        foreach(var scoreRecipe in Database.ScoreRecipes)
        {
            if(scoreRecipe.Action == Action)
            {
                return scoreRecipe.ScoreValue;
            }
        }

        return 0;
    }

    public int GetActionValue(int ActionID)
    {
        foreach(var scoreRecipe in Database.ScoreRecipes)
        {
            if((int)scoreRecipe.Action == ActionID)
            {
                return scoreRecipe.ScoreValue;
            }
        }

        return 0;
    }

    #endregion
}
