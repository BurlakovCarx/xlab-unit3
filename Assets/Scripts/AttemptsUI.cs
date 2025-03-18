using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AttemptsUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    private void Start()
    {
        FindObjectOfType<PlayerController>().onAttemptsChange.AddListener(Refresh);

        Refresh();
    }

    public void Refresh()
    {
        _text.text = $"Attempts: {FindObjectOfType<PlayerController>().attempts}/{FindObjectOfType<PlayerController>().maxAttempts}";
    }
}
