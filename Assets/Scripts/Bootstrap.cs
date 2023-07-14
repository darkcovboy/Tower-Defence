using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agava.YandexGames;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private LevelConfig _levelConfig;
    [Header("Level objects")]
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Player _player;
    [SerializeField] private MoneyCounter _moneyCounter;
    [SerializeField] private SpawnPlaceTower[] _spawnPlaceTower;
    [Header("UI")]
    [SerializeField] private VictoryScreen _victoryScreen;
    [SerializeField] private MoneyBalance _moneyBalance;
    [SerializeField] private AdButton _adButton;
    [Header("GameManager")]
    [SerializeField] private ObjectManagerUI _objectManagerUI;

    private Timer _timer;
    private CountPoints _countPoints;

    private void Awake()
    {
        InitMoneyCounter();
        InitTimer();
        _moneyCounter.Init(_levelConfig.StartMoney);
        _victoryScreen.Init(_objectManagerUI);
        _adButton.Init(_levelConfig.AdStartMoney, _moneyCounter);
        _countPoints = new CountPoints(_timer, _levelConfig.MoneyCoefficient, _levelConfig.TimeCoefficient, _levelConfig.HealthCoefficient);
    }

    private void OnEnable()
    {
        _spawner.AllEnemysDied += EndLevel;
    }

    private void OnDisable()
    {
        _spawner.AllEnemysDied -= EndLevel;
    }

    private int CountStars()
    {
        int index = 0;

        foreach (var healthStar in _levelConfig.HealthStars)
        {
            if(_player.CurrentHealth >= healthStar)
                index++;
        }

        return index;
    }

    private void EndLevel()
    {
        _timer.StopTimer();
        _victoryScreen.SetScore((int)_countPoints.Count(_player.MaxHealth, _player.CurrentHealth, _moneyCounter.Money));
        _victoryScreen.SetStars(CountStars());
    }

    private void InitMoneyCounter()
    {
        _spawner.Init(_moneyCounter);
        _moneyBalance.Init(_moneyCounter);

        foreach (var spawnPlaceTower in _spawnPlaceTower)
        {
            var selectButtons = spawnPlaceTower.gameObject.GetComponentsInChildren<SelectButton>(true);

            foreach (var selectButton in selectButtons)
            {
                selectButton.Init(_moneyCounter);
            }
        }
    }

    private void InitTimer()
    {
        _timer = new Timer(this);
        _timer.Set(_levelConfig.Time);
        _timer.StartTimer();
    }
}
