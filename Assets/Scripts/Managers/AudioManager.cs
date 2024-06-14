using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance = null;

    [SerializeField] private AudioSource bgmSource;

    [SerializeField] private AudioSource effectSource;
    [SerializeField] private AudioClip[] effectClips;

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
    public void PlayClickSound()
    {
        effectSource.clip = Array.Find(effectClips, clip => clip.name == "Click");
        effectSource.Play();
    }

    public void PlayJumpSound()
    {
        effectSource.clip = Array.Find(effectClips, clip => clip.name == "Jump");
        effectSource.Play();
    }
    public void PlayHitSound()
    {
        effectSource.clip = Array.Find(effectClips, clip => clip.name == "Hit");
        effectSource.Play();
    }
    public void PlayGameOverSound()
    {
        effectSource.clip = Array.Find(effectClips, clip => clip.name == "GameOver");
        effectSource.Play();
    }
}
