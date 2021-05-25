using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScoreDatabase", menuName = "New Score Database")]
public class ScoreDatabase : ScriptableObject
{
    public List<ScoreRecipe> ScoreRecipes;
}
