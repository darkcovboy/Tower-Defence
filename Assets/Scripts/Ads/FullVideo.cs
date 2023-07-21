using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agava.YandexGames;

public class FullVideo : MonoBehaviour
{
    private bool _isAudioOff;

    public void Show()
    {
        if(YandexGamesSdk.IsInitialized)
            InterstitialAd.Show(OnOpen, OnClose);
    }

    private void OnOpen()
    {
        _isAudioOff = AudioListener.pause;

        if (_isAudioOff == false)
            AudioListener.pause = true;

        Time.timeScale = 0f;
    }

    private void OnClose(bool isClosed)
    {
        if (_isAudioOff == false)
            AudioListener.pause = false;

        Time.timeScale = 1f;
    }
}
