using System;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance = null;
    public Image[] hpIcons;
    public Text scoreText;

    public GameObject introUI;
    public GameObject rankingUI;
    public GameObject ingameUI;
    public GameObject gameoverUI;
    public GameOverPanel gameoverPanel;

    [SerializeField] private Button rankingButton;
    public enum UIType
    {
        Intro,
        Ranking,
        InGame,
        GameOver
    };
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        rankingButton.onClick.AddListener(delegate
        {
            AudioManager.instance.PlayEffect(AudioManager.EffectType.Click);
            ChangeUI(UIType.Ranking);
        });
    }
    public void OnClickJump()
    {
        GameManager.instance.character.inputJump = true;
    }
    public void ChangeCrouch(bool _inputCrouch)
    {
        GameManager.instance.character.inputCrouch = _inputCrouch;
    }
    public void ChangeUI(UIType _type)
    {
        introUI.SetActive(_type == UIType.Intro);
        rankingUI.SetActive(_type == UIType.Ranking);
        ingameUI.SetActive(_type == UIType.InGame);
        gameoverUI.SetActive(_type == UIType.GameOver);
    }
    public void SetScore(float _score)
    {
        scoreText.text = ScoreManager.instance.SetScoreString(_score);
    }
}
