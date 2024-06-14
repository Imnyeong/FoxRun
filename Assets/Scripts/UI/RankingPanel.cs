using UnityEngine;
using UnityEngine.UI;

public class RankingPanel : MonoBehaviour
{
    [SerializeField] private Text[] rankingText;
    [SerializeField] private Button backButton;

    private void Awake()
    {
        backButton.onClick.AddListener(delegate
        {
            AudioManager.instance.PlayEffect(AudioManager.EffectType.Click);
            UIManager.instance.ChangeUI(UIManager.UIType.Intro);
        });
    }
    private void OnEnable()
    {
        SetRanking();
    }
    private void SetRanking()
    {
        float[] ranking = ScoreManager.instance.LoadRecords();
        rankingText[0].text = $"1st {ScoreManager.instance.SetScoreString(ranking[0])}";
        rankingText[1].text = $"2nd {ScoreManager.instance.SetScoreString(ranking[1])}";
        rankingText[2].text = $"3rd {ScoreManager.instance.SetScoreString(ranking[2])}";
    }
}
