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

    public event UnityAction PlayerIsAlive;

    public void Init(int money, RewardedVideo rewardedVideo)
    {
        _money = money;
        _moneyText.text = _money.ToString();
        var button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(() => rewardedVideo.Show(adType));
        button.onClick.AddListener(gameObject.Deactivate);
    }

    public void Init(RewardedVideo rewardedVideo, GameOverScreen gameOverScreen)
    {
        var button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(() => rewardedVideo.Show(adType));
        button.onClick.AddListener(() => PlayerIsExtraLive());
        button.onClick.AddListener(gameOverScreen.CloseScreen);
    }

    private void PlayerIsExtraLive()
    {
        _timeToSpawn.SetPlayerAlive();
    }
}
