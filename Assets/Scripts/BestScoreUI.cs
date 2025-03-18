using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BestScoreUI : MonoBehaviour
{
    [SerializeField] private ScoreManager _scoreManager;
    [SerializeField] private TMP_Text _bestScoreText;

    private void Start()
    {
        FindObjectOfType<ScoreManager>().onBestScoreChange.AddListener(Refresh);

        Refresh();
    }

    private void Refresh()
    {
        _bestScoreText.text = $"Best score: {_scoreManager.bestScore}";
    }
}