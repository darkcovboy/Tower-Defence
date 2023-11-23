using UnityEngine;
using Agava.YandexGames;

public class FullVideo
{
    private const float MaxVolume = 1.0f;
    private const float MinVolume = 0f;

    private bool _isAudioOff;
    private string _sceneName;
    private LoadingPanel _loadingPanel;

    public FullVideo(LoadingPanel loadingPanel)
    {
        _loadingPanel = loadingPanel;
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
        AudioListener.pause = true;
        AudioListener.volume = MinVolume;
        Time.timeScale = 0f;
    }

    private void OnClose(bool isClosed)
    {
        AudioListener.pause = _isAudioOff;
        AudioListener.volume = MaxVolume;
        Time.timeScale = 1f;
        _loadingPanel.LoadLevel(_sceneName);
    }
}
