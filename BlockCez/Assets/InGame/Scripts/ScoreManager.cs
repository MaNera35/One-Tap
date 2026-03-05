using UnityEngine;
using System;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    private int score;
    private int highScore;

    public static event Action<int> OnScoreChanged;

    private void Awake()
    {
        Instance = this;
        highScore = PlayerPrefs.GetInt("HIGH_SCORE", 0);
    }

    public void AddScore(int amount)
    {
        score += amount;
        OnScoreChanged?.Invoke(score);

        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HIGH_SCORE", highScore);
        }
    }

    public void ResetScore()
    {
        score = 0;
        OnScoreChanged?.Invoke(score);
    }

    public int GetScore() => score;
    public int GetHighScore() => highScore;
}