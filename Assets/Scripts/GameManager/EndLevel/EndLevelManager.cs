using UnityEngine;
using Zenject;

public class EndLevelManager : MonoBehaviour
{
    private Timer _timer;
    private IDiedHandler _diedHandler;
    private Player _player;
    private CountPoints _countPoints;
    private LevelConfig _levelConfig;
    private MoneyCounter _moneyCounter;
    private SaveManager _saveManager;
    private VictoryScreen _victoryScreen;

    private void OnDisable()
    {
        _diedHandler.AllEnemysDied -= WinLevel;
        _player.OnDie -= LoseLevel;
    }

    [Inject]
    public void Init(IDiedHandler allDiedHandler, Player died, LevelConfig levelConfig , VictoryScreen victoryScreen, SaveManager saveManager, MoneyCounter moneyCounter)
    {
        _diedHandler = allDiedHandler;
        _diedHandler.AllEnemysDied += WinLevel;
        _player = died;
        _player.OnDie += LoseLevel;
        _levelConfig = levelConfig;
        _moneyCounter = moneyCounter;
        _saveManager = saveManager;
        _victoryScreen = victoryScreen;
        InitTimer(levelConfig.Time);
        _countPoints = new(_timer, _levelConfig.MoneyCoefficient, _levelConfig.TimeCoefficient, _levelConfig.HealthCoefficient);
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
        var points = (int)_countPoints.Count(_player.MaxHealth, _player.CurrentHealth, _moneyCounter.Money);
        _victoryScreen.SetScore(points);
        _victoryScreen.SetStars(stars);
        _victoryScreen.PlayShowStars();
        _saveManager.SaveEndLevel(stars, points);
    }
}
