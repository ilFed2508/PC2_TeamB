using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Jobs;

[System.Serializable]
public class ScoreRecipe
{
    [SerializeField]
    public ScoreAction Action;
    [SerializeField]
    public int ScoreValue;
}
