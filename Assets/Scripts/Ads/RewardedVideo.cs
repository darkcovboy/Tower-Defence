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
    [SerializeField] private float _radius;

    private MoneyCounter _moneyCounter;
    private int _money;
    private int _adHealth;
    private Player _player;
    private Spawner _spawner;

    private bool _isAudioOff;

    public void Init(MoneyCounter moneyCounter, Player player, int adMoney, int adHealth, Spawner spawner)
    {
        _moneyCounter = moneyCounter;
        _money = adMoney;
        _player = player;
        _adHealth = adHealth;
        _spawner = spawner;
        transform.position = _player.transform.position;
    }

    public void Show(ShowType showType)
    {
        switch (showType)
        {
            case ShowType.Money:
                VideoAd.Show(OnOpen, OnRewardedMoney, OnClose);
                break;
            case ShowType.Health:
                VideoAd.Show(OnOpen, OnRewardedHealth, OnClose);
                break;
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
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, _radius, 1, QueryTriggerInteraction.Collide);

        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.TryGetComponent<Enemy>(out Enemy enemy))
            {
                switch(enemy.EnemyType)
                {
                    case (EnemyType.Common):
                        {
                            enemy.TakeDamage(enemy.CurrentHealth);
                            break;
                        }
                    case (EnemyType.Boss):
                        {
                            enemy.RollBack();
                            break;
                        }
                }
            }
        }

        _player.AddHealth(_adHealth);
    }

    private void OnClose()
    {
        if(_isAudioOff == false)
            AudioListener.pause = false;

        Time.timeScale = 1f;
    }
}
