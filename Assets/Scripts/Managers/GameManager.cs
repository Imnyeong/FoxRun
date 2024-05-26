using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public bool isPlay = false;
    public GameObject StartButton;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    public void GameStart()
    {
        isPlay = true;
        StartButton.SetActive(false);
        AudioManager.instance.PlayClickSound();
        Character.instance.Move(isPlay);
        UIManager.instance.ShowUI();
        ScoreManager.instance.StartScore();
    }
    public void GameOver()
    {
        isPlay = false;
        AudioManager.instance.PlayGameOverSound();
        Character.instance.Move(isPlay);
        UIManager.instance.HideUI();
        UIManager.instance.gameoverPanel.ShowPanel(ScoreManager.instance.score);
    }
}
