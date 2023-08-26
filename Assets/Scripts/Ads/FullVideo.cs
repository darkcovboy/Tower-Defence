using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agava.YandexGames;
using UnityEngine.SceneManagement;

public class FullVideo : MonoBehaviour
{
    private bool _isAudioOff;
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

        if (_isAudioOff == false)
            AudioListener.pause = true;

        Time.timeScale = 0f;
    }

    private void OnClose(bool isClosed)
    {
        if (_isAudioOff == true)
            AudioListener.pause = false;

        Time.timeScale = 1f;
        SceneManager.LoadScene(_sceneName);
    }
}
