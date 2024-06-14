using System.Collections;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance = null;
    [HideInInspector] public float score { get; private set; } = 0.0f;
    private float scoreDelay = 1.0f;
    private float scoreValue = 0.1f;
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
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
}
