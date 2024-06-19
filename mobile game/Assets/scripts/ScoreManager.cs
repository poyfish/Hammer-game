using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int Score;

    public bool SaveMode;

    private string ScoreKey = "Score";

    private void Awake()
    {
        if (SaveMode) LoadScore();
    }

    public void AddScore(int score)
    {
        Score += score;

        if (SaveMode) SaveScore();
    }

    public void RemoveScore(int score)
    {
        Score -= score;

        if(SaveMode) SaveScore();
    }

    public void SaveScore()
    {
        PlayerPrefs.SetInt(ScoreKey, Score);

        PlayerPrefs.Save();
    }

    public void LoadScore()
    {
        Score = PlayerPrefs.GetInt(ScoreKey);
    }

    [Button("delete data")]
    public void ClearSaveData()
    {
        PlayerPrefs.DeleteKey(ScoreKey);

        Score = 0;
    }
}
