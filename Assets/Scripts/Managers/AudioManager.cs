using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance = null;

    [SerializeField] private AudioSource bgmSource;

    [SerializeField] private AudioSource effectSource;
    [SerializeField] private AudioClip[] effectClips;
    public enum EffectType
    {
        Click,
        Jump,
        Hit,
        GameOver
    };

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        bgmSource.Play();
    }
    public void PlayEffect(EffectType _type)
    {
        switch(_type)
        {
            case EffectType.Click:
                {
                    effectSource.clip = Array.Find(effectClips, clip => clip.name == "Click");
                    break;
                }
            case EffectType.Jump:
                {
                    effectSource.clip = Array.Find(effectClips, clip => clip.name == "Jump");
                    break;
                }            
            case EffectType.Hit:
                {
                    effectSource.clip = Array.Find(effectClips, clip => clip.name == "Hit");
                    break;
                }            
            case EffectType.GameOver:
                {
                    effectSource.clip = Array.Find(effectClips, clip => clip.name == "GameOver");
                    break;
                }
        }
        effectSource.Play();
    }
}