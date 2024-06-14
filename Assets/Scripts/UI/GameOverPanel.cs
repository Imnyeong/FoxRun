using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverPanel : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private Button replayButton;
    [SerializeField] private Button exitButton;

    private const float km = 1000.0f;

    private void Awake()
    {
        replayButton.onClick.AddListener(delegate 
        {
            AudioManager.instance.PlayEffect(AudioManager.EffectType.Click);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        });
        exitButton.onClick.AddListener(delegate
        {
            AudioManager.instance.PlayEffect(AudioManager.EffectType.Click);
            Application.Quit();
        });
    }

    public void ShowPanel(float _score)
    {
        if (_score >= km)
        {
            scoreText.text = $"Your Score\n{(_score / km).ToString("F1")} km";
        }
        else
        {
            scoreText.text = $"Your Score\n{_score.ToString("F1")} m";
        }
        this.gameObject.SetActive(true);
    }
}
