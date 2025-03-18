using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private ScoreManager _scoreManager;
    [SerializeField] private TMP_Text _scoreText;

    private void Start()
    {
        FindObjectOfType<ScoreManager>().onScoreChange.AddListener(Refresh);

        Refresh();
    }

    private void Refresh()
    {
        _scoreText.text = $"Score: {_scoreManager.score}";
    }
}
