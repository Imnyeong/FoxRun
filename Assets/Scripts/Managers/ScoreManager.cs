using System;
using System.Collections;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance = null;
    [HideInInspector] public float score { get; private set; } = 0.0f;
    private const float scoreDelay = 0.5f;
    private const float scoreValue = 0.1f;

    private float[] currentRanking = new float[3];
    private const float km = 1000.0f;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public void Start()
    {
        InitRanking();
    }
    public void InitRanking()
    {
        if (!PlayerPrefs.HasKey("Rank_0"))
        {
            for (int i = 0; i < currentRanking.Length; i++)
            {
                PlayerPrefs.SetFloat($"Rank_{i}", 0);
            }
        }
        currentRanking = LoadRecords();
    }
    public void StartScore()
    {
        StartCoroutine(ScoreCoroutine());
    }
    private IEnumerator ScoreCoroutine()
    {
        yield return new WaitForSecondsRealtime(scoreDelay);

        if(GameManager.instance.isRunning())
        {
            score += scoreValue;
            UIManager.instance.SetScore(score);
        }

        if(GameManager.instance.isPlay)
        {
            StartCoroutine(ScoreCoroutine());
        }
        else
        {
            StopCoroutine(ScoreCoroutine());
        }
    }

    public void SaveRecords(float _score)
    {
        if(currentRanking[currentRanking.Length - 1] < _score)
        {
            currentRanking[currentRanking.Length - 1] = _score;

            Array.Sort(currentRanking);
            Array.Reverse(currentRanking);

            for (int i = 0; i < currentRanking.Length; i++)
            {
                PlayerPrefs.SetFloat($"Rank_{i}", currentRanking[i]);
            }
        }
    }
    public float[] LoadRecords()
    {
        float[] ranking = new float[3];
        for(int i = 0; i< ranking.Length; i++)
        {
            ranking[i] = PlayerPrefs.GetFloat($"Rank_{i}");
        }
        return ranking;
    }
    public string SetScoreString(float _value)
    {
        return _value >= km ? $"{(_value / km).ToString("F1")} km" : $"{_value.ToString("F1")} m";
    }
}
