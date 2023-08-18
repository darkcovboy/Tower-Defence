using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class AdButton : MonoBehaviour
{
    [SerializeField] private ShowType adType;
    [SerializeField] private TextMeshProUGUI _moneyText;
    [SerializeField] private float _radius;
    [SerializeField] private Player _player;
    [SerializeField] private TimeToSpawnNextWaveScreen _timeToSpawn;

    private int _money;
    private SoundButton _soundButton; 

    public event UnityAction PlayerIsAlive;

    public void Init(int money, RewardedVideo rewardedVideo, SoundButton soundButton)
    {
        _money = money;
        _moneyText.text = _money.ToString();
        _soundButton = soundButton;
        var button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(()=>_soundButton.Play());
        button.onClick.AddListener(() => rewardedVideo.Show(adType));
        button.onClick.AddListener(gameObject.Deactivate);
    }

    public void Init(RewardedVideo rewardedVideo, GameOverScreen gameOverScreen, SoundButton soundButton)
    {
        _soundButton = soundButton;
        var button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(()=>_soundButton.Play());
        button.onClick.AddListener(() => rewardedVideo.Show(adType));
        button.onClick.AddListener(() => PlayerIsExtraLive());
        button.onClick.AddListener(gameOverScreen.CloseScreen);
        button.onClick.AddListener(gameObject.Deactivate);
    }

    private void PlayerIsExtraLive()
    {
        _timeToSpawn.PlayerIsAliveNow();
    }
}
