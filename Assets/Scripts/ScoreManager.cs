using System.Collections;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance = null;
    [HideInInspector] public float score = 0.0f;
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
        yield return new WaitForSecondsRealtime(1.0f);

        if(GameManager.instance.isPlay && !Character.instance.isCrouch)
        {
            score += 0.1f;
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
