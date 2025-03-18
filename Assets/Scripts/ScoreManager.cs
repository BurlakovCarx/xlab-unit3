using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
    public int score { get; private set; }
    public int bestScore { get; private set; }
    public UnityEvent onScoreChange = new();
    public UnityEvent onBestScoreChange = new();

    private const string BEST_SCORE_KEY = "best_score";

    private void Start()
    {
        if(PlayerPrefs.HasKey(BEST_SCORE_KEY))
        {
            bestScore = PlayerPrefs.GetInt(BEST_SCORE_KEY);
        }
        else 
            bestScore = 0;
        score = 0;
    }

    public void SetScore(int score)
    {
        this.score = score;
        onScoreChange.Invoke();

        if (score >= bestScore)
        {
            bestScore = score;
            PlayerPrefs.SetInt(BEST_SCORE_KEY, bestScore);
            onBestScoreChange.Invoke();
        }
    }

    public void AddPoint()
    {
        SetScore(score + 1);      
    }
}
