using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance = null;
    public Image[] hpIcons;
    public Text scoreText;
    public GameOverPanel gameoverPanel;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    public void OnClickJump()
    {
        Character.instance.inputJump = true;
    }
    public void PointerDownCrouch()
    {
        Character.instance.inputCrouch = true;
    }
    public void PointerUpCrouch()
    {
        Character.instance.inputCrouch = false;
    }
    public void ShowUI()
    {
        foreach(Image image in hpIcons)
        {
            image.color = new Color32(255, 255, 255, 255);
        }
        scoreText.gameObject.SetActive(true);
    }
    public void HideUI()
    {
        foreach (Image image in hpIcons)
        {
            image.color = new Color32(255, 255, 255, 0);
        }
        scoreText.gameObject.SetActive(false);
    }
    public void SetScore(float _score)
    {
        if(_score >= 1000.0f)
        {
            scoreText.text = $"{(_score / 1000.0f).ToString("F1")} km";
        }
        else
        {
            scoreText.text = $"{_score.ToString("F1")} m";
        }
    }
}
