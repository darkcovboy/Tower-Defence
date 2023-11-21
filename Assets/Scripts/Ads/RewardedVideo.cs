using UnityEngine;
using Agava.YandexGames;

public abstract class RewardedVideo
{
    private bool _isAudioOff;

    public void Show()
    {
        VideoAd.Show(OnOpenCallback, OnRewardedCallback, OnCloseCallback);
    }

    private void OnOpenCallback()
    {
        _isAudioOff = AudioListener.pause;

        AudioListener.pause = true;

        Time.timeScale = 0f;
    }

    protected abstract void OnRewardedCallback();
    
    private void OnCloseCallback()
    {
        if(_isAudioOff == false)
            AudioListener.pause = false;

        Time.timeScale = 1f;
    }
}
