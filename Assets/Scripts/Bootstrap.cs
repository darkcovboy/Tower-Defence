using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private Timer _timer;
    private CountPoints _countPoints;

    private void Awake()
    {
        _spawner.Init(_moneyCounter);
        _moneyBalance.Init(_moneyCounter);
        InitMoneyCounter();
        _timer = new Timer(this);
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

    private void EndLevel()
    {
        _timer.StopTimer();
        _victoryScreen.SetScore(_countPoints.Count(_player.MaxHealth, _player.CurrentHealth, _moneyCounter.Money));
    }

    private void InitMoneyCounter()
    {
        

        foreach (var spawnPlaceTower in _spawnPlaceTower)
        {
            var selectButtons = spawnPlaceTower.gameObject.GetComponentsInChildren<SelectButton>(true);

            foreach (var selectButton in selectButtons)
            {
                selectButton.Init(_moneyCounter);
            }
        }
    }
}
