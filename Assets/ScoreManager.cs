using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using TMPro;
using Mirror;

public class ScoreManager : NetworkBehaviour
{
    [SyncVar(hook = nameof(OnScoreChanged))]
    public int score;

    public static ScoreManager instance;
    public TextMeshProUGUI scoreText;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    [Server]
    public void AddScore(int points)
    {
        score += points;
    }

    void OnScoreChanged(int oldScore, int newScore)
    {
        scoreText.text = newScore.ToString();
    }
}
