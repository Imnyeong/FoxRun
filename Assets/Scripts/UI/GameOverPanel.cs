using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverPanel : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private Button replayButton;
    [SerializeField] private Button exitButton;

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
        scoreText.text = $"Your Score\n{ScoreManager.instance.SetScoreString(_score)}";
        ScoreManager.instance.SaveRecords(_score);
        this.gameObject.SetActive(true);
    }
}