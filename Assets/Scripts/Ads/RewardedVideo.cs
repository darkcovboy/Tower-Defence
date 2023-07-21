using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agava.YandexGames;

public enum ShowType
{
    Money,
    Health
}

public class RewardedVideo : MonoBehaviour
{
    private MoneyCounter _moneyCounter;
    private int _money;
    private int _adHelath;
    private Player _player;

    private bool _isAudioOff;

    public void Init(MoneyCounter moneyCounter, Player player, int adMoney, int adHealth)
    {
        _moneyCounter = moneyCounter;
        _money = adMoney;
        _player = player;
        _adHelath = adMoney;
    }

    public void Show(ShowType showType)
    {
        if(YandexGamesSdk.IsInitialized)
        {
            switch(showType)
            {
                case ShowType.Money:
                    VideoAd.Show(OnOpen, OnRewardedMoney, OnClose);
                    break;
                case ShowType.Health:
                    VideoAd.Show(OnOpen, OnRewardedHealth, OnClose);
                    break;
            }
        }
    }

    private void OnOpen()
    {
        _isAudioOff = AudioListener.pause;

        if (_isAudioOff == false)
            AudioListener.pause = true;

        Time.timeScale = 0f;
    }

    private void OnRewardedMoney()
    {
        _moneyCounter.AddMoney(_money);
    }

    private void OnRewardedHealth()
    {
        _player.AddHealth(_adHelath);
    }

    private void OnClose()
    {
        if(_isAudioOff == false)
            AudioListener.pause = false;

        Time.timeScale = 1f;
    }
}
