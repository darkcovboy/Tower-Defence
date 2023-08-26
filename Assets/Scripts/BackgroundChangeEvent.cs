using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agava.WebUtility;

public class BackgroundChangeEvent : MonoBehaviour
{
    private AudioManager _audioManager;
    private PauseScreen _pauseScreen;

    private bool _isAudioOff;

    private void OnEnable()
    {
        WebApplication.InBackgroundChangeEvent += OnInBackgroundChange;
    }

    private void OnDisable()
    {
        WebApplication.InBackgroundChangeEvent -= OnInBackgroundChange;
    }

    public void Init(AudioManager audioManager, PauseScreen pauseScreen)
    {
        _audioManager = audioManager;
        _pauseScreen = pauseScreen;
    }

    private void OnInBackgroundChange(bool inBackground)
    {
        _isAudioOff = AudioListener.pause;

        if (inBackground == true)
        {
            AudioListener.pause = true;
        }
        else
        {
            AudioListener.pause = _isAudioOff;
        }

        Time.timeScale = inBackground ? 0f : 1;

        AudioListener.volume = inBackground ? 0f : _audioManager.CurrentVolume;
    }
}
