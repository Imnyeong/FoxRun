using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public Character character;
    public bool isPlay { get; private set; } = false;
    public Button StartButton;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    public bool isRunning()
    {
        return isPlay && !character.isCrouch;
    }
    public void GameStart()
    {
        isPlay = true;
        StartButton.gameObject.SetActive(false);
        character.Move(isPlay);

        AudioManager.instance.PlayEffect(AudioManager.EffectType.Click);
        UIManager.instance.ChangeUI(UIManager.UIType.InGame);
        ScoreManager.instance.StartScore();
    }
    public void GameOver()
    {
        isPlay = false;
        character.Move(isPlay);

        AudioManager.instance.PlayEffect(AudioManager.EffectType.GameOver);
        UIManager.instance.ChangeUI(UIManager.UIType.GameOver);
        UIManager.instance.gameoverPanel.ShowPanel(ScoreManager.instance.score);
    }
}
