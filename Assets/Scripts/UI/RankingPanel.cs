using UnityEngine;
using UnityEngine.UI;

public class RankingPanel : MonoBehaviour
{
    [SerializeField] private Text[] rankingText;
    [SerializeField] private Button backButton;

    private const float km = 1000.0f;

    private void Awake()
    {
        backButton.onClick.AddListener(delegate
        {
            UIManager.instance.ChangeUI(UIManager.UIType.Intro);
        });
    }

    public void OnEnable()
    {

    }
}
