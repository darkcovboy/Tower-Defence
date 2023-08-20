using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class AdButton : MonoBehaviour
{
    [SerializeField] private Button _adButton;
    [SerializeField] private ShowType adType;
    [SerializeField] private TextMeshProUGUI _moneyText;
    [SerializeField] private float _radius;
    [SerializeField] private float _timeToShow;

    private int _money;
    private SoundButton _soundButton;
    private Player _player;
    private TimeToSpawnNextWaveScreen _timeToSpawn;

    public event UnityAction PlayerIsAlive;

    private void OnDisable()
    {
        StopCoroutine(OnTimeGoing());
    }

    public void Init(int money, RewardedVideo rewardedVideo, SoundButton soundButton)
    {
        _money = money;
        _moneyText.text = _money.ToString();
        _soundButton = soundButton;
        
        _adButton.onClick.AddListener(()=>_soundButton.Play());
        _adButton.onClick.AddListener(() => rewardedVideo.Show(adType));
        _adButton.onClick.AddListener(gameObject.Deactivate);
        StartCoroutine(OnTimeGoing());
    }

    public void Init(RewardedVideo rewardedVideo, GameOverScreen gameOverScreen, SoundButton soundButton, Player player, TimeToSpawnNextWaveScreen timeToSpawnNextWaveScreen)
    {
        _soundButton = soundButton;
        _player = player;
        _timeToSpawn = timeToSpawnNextWaveScreen;
        _adButton.onClick.AddListener(()=>_soundButton.Play());
        _adButton.onClick.AddListener(() => rewardedVideo.Show(adType));
        _adButton.onClick.AddListener(() => PlayerIsExtraLive());
        _adButton.onClick.AddListener(gameOverScreen.CloseScreen);
    }

    private IEnumerator OnTimeGoing()
    {
        _adButton.gameObject.Deactivate();
        yield return new WaitForSeconds(_timeToShow);
        _adButton.gameObject.Activate();
    }

    private void PlayerIsExtraLive()
    {
        _timeToSpawn.SetPlayerAlive();
    }
}
