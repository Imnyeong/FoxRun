using System;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance = null;
    public Image[] hpIcons;
    public Text scoreText;
    public GameOverPanel gameoverPanel;

    private const float km = 1000.0f;

    private Color32[] hpColors = new Color32[]
    {
        new Color32(255, 255, 255, 0),
        new Color32(255, 255, 255, 255)
    };
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    public void OnClickJump()
    {
        GameManager.instance.character.inputJump = true;
    }
    public void ChangeCrouch(bool _inputCrouch)
    {
        GameManager.instance.character.inputCrouch = _inputCrouch;
    }
    public void ActiveUI(bool _isShow)
    {
        foreach(Image image in hpIcons)
        {
            image.color = hpColors[Convert.ToInt32(_isShow)];
        }
        scoreText.gameObject.SetActive(_isShow);
    }
    public void SetScore(float _score)
    {
        if(_score >= km)
        {
            scoreText.text = $"{(_score / km).ToString("F1")} km";
        }
        else
        {
            scoreText.text = $"{_score.ToString("F1")} m";
        }
    }
}
