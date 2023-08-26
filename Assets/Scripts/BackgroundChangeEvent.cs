using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agava.WebUtility;

public class BackgroundChangeEvent : MonoBehaviour
{
    [SerializeField] private AudioManager _audioManager;

    private void OnEnable()
    {
        WebApplication.InBackgroundChangeEvent += OnInBackgroundChange;
    }

    private void OnDisable()
    {
        WebApplication.InBackgroundChangeEvent -= OnInBackgroundChange;
    }

    public void Init(AudioManager audioManager)
    {
        _audioManager = audioManager;
    }

    private void OnInBackgroundChange(bool inBackground)
    {
        AudioListener.pause = inBackground;
        AudioListener.volume = inBackground ? 0f : _audioManager.CurrentVolume;
        Time.timeScale = inBackground ? 0f : 1f;
    }
}
