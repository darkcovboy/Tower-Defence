using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agava.WebUtility;

public class BackgroundChangeEvent : MonoBehaviour
{
    private AudioManager _audioManager;

    private bool _isAudioOff;
    private float _timeScale;

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
        if(inBackground == true)
        {
            _isAudioOff = AudioListener.pause;
            _timeScale = Time.timeScale;
            Time.timeScale = 0f;
            AudioListener.pause = true;
            AudioListener.volume = 0f;
        }

        if (inBackground == false)
        {
            AudioListener.pause = _isAudioOff;
            AudioListener.volume = _audioManager.CurrentVolume;

            if (_timeScale != 0)
            {
                Time.timeScale = _timeScale;
            }
        }
    }
}
