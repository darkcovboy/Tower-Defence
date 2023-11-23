using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agava.WebUtility;

public class BackgroundChangeEvent
{
    private bool _isAudioOff;
    private float _timeScale;

    public BackgroundChangeEvent()
    {
        WebApplication.InBackgroundChangeEvent += OnInBackgroundChange;
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

            if (_timeScale != 0)
            {
                Time.timeScale = _timeScale;
            }
        }
    }
}
