using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agava.YandexGames;
using UnityEngine.SceneManagement;

public class FullVideo : MonoBehaviour
{
    private bool _isAudioOff;
    private float _volume;
    private string _sceneName;
    private SceneFader _sceneFader;

    public void Init(SceneFader sceneFader)
    {
        _sceneFader = sceneFader;
    }

    public void Show(string sceneName)
    {
        _sceneName = sceneName;

        if (YandexGamesSdk.IsInitialized)
            InterstitialAd.Show(OnOpen, OnClose);
    }

    private void OnOpen()
    {
        _isAudioOff = AudioListener.pause;
        _volume = AudioListener.volume;
        AudioListener.pause = true;
        AudioListener.volume = 0;
        Time.timeScale = 0f;
    }

    private void OnClose(bool isClosed)
    {
        AudioListener.pause = _isAudioOff;
        AudioListener.volume = _volume;
        Time.timeScale = 1f;
        SceneManager.LoadScene(_sceneName);
    }
}
