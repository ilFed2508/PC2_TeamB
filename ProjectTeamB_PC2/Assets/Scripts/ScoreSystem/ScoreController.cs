using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ScoreController : MonoBehaviour
{
    [SerializeField]
    private ScoreDatabase Database;
    [SerializeField]
    private int StartingScore;
    [SerializeField]
    private int CurrentScore;
    [SerializeField]
    private int TotalScore;

    // Start is called before the first frame update
    void Start()
    {
        Initialize();   
    }

    #region BehaviourAPI

    public void Initialize()
    {
        //set Current score => starting score
        CurrentScore = StartingScore;
        TotalScore = StartingScore;

        //controllo variabili
        if(Database == null)
        {
            Debug.LogError("Non hai messo la referenza al database nello ScoreController!");
        }
        else
        {
            //controllo database corretto
            for (int i = 1; i < 4; i++)
            {
                int ActionCounter = Database.ScoreRecipes.Count(act => (int)act.Action == i);

                if(ActionCounter > 1)
                {
                    Debug.LogWarning("Attento hai 2 azioni uguali nello scriptable ScoreDatabase!");
                }
            }
        }
        
        
    }

    public void AddScore(int ActionID)
    {
        CurrentScore += GetActionValue(ActionID);
        TotalScore += GetActionValue(ActionID);
    }

    public void RemoveScore(int ActionID)
    {
        CurrentScore -= GetActionValue(ActionID);

        if(CurrentScore < 0)
        {
            CurrentScore = 0;
        }

        TotalScore -= GetActionValue(ActionID);

        if(TotalScore < 0)
        {
            TotalScore = 0;
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
    #endregion

    #region DebugAPI

    public ScoreDatabase GetDatabase() => Database;

    public int GetStartingScore() => StartingScore;

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
