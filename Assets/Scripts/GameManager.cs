using System.Collections;
using System.Collections.Generic;
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
        Character.instance.Move(isPlay);
    }
    public void GameOver()
    {
        isPlay = false;
        StartButton.SetActive(true);
        Character.instance.Move(isPlay);
    }
}
