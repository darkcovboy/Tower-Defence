using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevelManager : MonoBehaviour
{
    private Timer _timer;
    private Spawner _spawner;
    private Player _player;
    private CountPoints _countPoints;
    private LevelConfig _levelConfig;
    private MoneyCounter _moneyCounter;
    private SaveManager _saveManager;
    private VictoryScreen _victoryScreen;

    private void OnDisable()
    {
        _spawner.AllEnemysDied -= WinLevel;
        _player.Dying -= LoseLevel;
    }

    public void Init(Spawner spawner, Player player, LevelConfig levelConfig,VictoryScreen victoryScreen, SaveManager saveManager, MoneyCounter moneyCounter)
    {
        _spawner = spawner;
        _player = player;
        _levelConfig = levelConfig;
        _moneyCounter = moneyCounter;
        _saveManager = saveManager;
        _victoryScreen = victoryScreen;
        InitTimer(levelConfig.Time);
        _countPoints = new(_timer, _levelConfig.MoneyCoefficient, _levelConfig.TimeCoefficient, _levelConfig.HealthCoefficient);
        _spawner.AllEnemysDied += WinLevel;
        _player.Dying += LoseLevel;
    }

    private int CountStars()
    {
        int index = 0;

        foreach (var healthStar in _levelConfig.HealthStars)
        {
            if (_player.CurrentHealth >= healthStar)
                index++;
        }

        return index;
    }

    private void InitTimer(float time)
    {
        _timer = new Timer(this);
        _timer.Set(time);
        _timer.StartTimer();
    }

    private void LoseLevel()
    {
        _timer.StopTimer();
    }

    private void WinLevel()
    {
        _timer.StopTimer();
        var stars = CountStars();
        Debug.Log(_countPoints.Time + " " + _countPoints.RemainTime);
        var points = (int)_countPoints.Count(_player.MaxHealth, _player.CurrentHealth, _moneyCounter.Money);
        _victoryScreen.SetScore(points);
        _victoryScreen.SetStars(stars);
        _victoryScreen.PlayShowStars();
        //_saveManager.SaveEndLevel(stars, points);
    }
}
