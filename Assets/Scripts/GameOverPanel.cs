using System.Collections;
using System.Collections.Generic;
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
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        });
        exitButton.onClick.AddListener(delegate
        {
            Application.Quit();
        });
    }

    public void ShowPanel(float _score)
    {
        if (_score >= 1000.0f)
        {
            scoreText.text = $"Your Score\n{(_score / 1000.0f).ToString("F1")} km";
        }
        else
        {
            scoreText.text = $"Your Score\n{_score.ToString("F1")} m";
        }
        this.gameObject.SetActive(true);
    }
}
