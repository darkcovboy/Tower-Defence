using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    [SerializeField] protected Wavesss[] _waves;
    [SerializeField] private Transform[] _spawnPoint;
    [SerializeField] private Player _player;
    [SerializeField] private Warrior _warrior;
    [SerializeField] private Transform _container;

    private Wavesss _currentWave;
    private int _currentWaveNumber = 0;
    private float _timeAfterlastSpawn;
    private int _spawned;
    private int _currentEnemyIndex;
    private List<Enemy> _enemyLiev = new List<Enemy>();
    private bool _checkTimerWaveSpawn = false;
    private MoneyCounter _moneyCounter;

    public int EnemySpawnCount { get; private set; }

    public event UnityAction AllEnemysSpawned;
    public event UnityAction AllEnemysDied;
    public event UnityAction<int, int> EnemyCountChanged;

    private void Start()
    {
        _moneyCounter = FindObjectOfType<MoneyCounter>();
        SetWave(_currentWaveNumber);
    }

    private void Update()
    {
        if (_currentWave == null || _currentWave.wavesSettings == null)
        {
            for (int i = 0; i < _enemyLiev.Count; i++)
            {
                if (_enemyLiev[i].gameObject.activeSelf == false)
                {
                    _enemyLiev.Remove(_enemyLiev[i]);
                }
            }

            if (_enemyLiev.Count == 0)
            {
                AllEnemysDied?.Invoke();
            }
            else
                return;
        }

        _timeAfterlastSpawn += Time.deltaTime;

        if (_checkTimerWaveSpawn == false)
        {
            if (_timeAfterlastSpawn >= _waves[_currentWaveNumber].wavesSettings[_currentEnemyIndex].Delay)
            {
                InstantiateEnemy();
                _spawned++;
                _timeAfterlastSpawn = 0;
                EnemyCountChanged?.Invoke(_spawned, _waves[_currentWaveNumber].wavesSettings.Length);
                _currentEnemyIndex++;
                EnemySpawnCount++;
            }
        }

        if (_waves[_currentWaveNumber].wavesSettings.Length <= _spawned)
        {
            if (_waves.Length > _currentWaveNumber + 1)
            {
                //NextWaves();
                AllEnemysSpawned?.Invoke();
                _checkTimerWaveSpawn = true;
            }

            else
            {
                _currentWave = null;
                _currentEnemyIndex = 0;
            }
        }
    }

    private void InstantiateEnemy()
    {
        int indexArray = Random.Range(0, _spawnPoint.Length);
        Enemy enemy = Instantiate(_waves[_currentWaveNumber].wavesSettings[_currentEnemyIndex].Template, _spawnPoint[indexArray].position, _spawnPoint[indexArray].rotation, _container).GetComponent<Enemy>();
        enemy.Init(_player, _warrior);
        enemy.Dying += OnEnemyDying;
        enemy.GetIndexToArray(indexArray);
        _enemyLiev.Add(enemy);
    }

    private void SetWave(int index)
    {
        _currentWave = _waves[index];
    }

    private void OnEnemyDying(Enemy enemy)
    {
        enemy.Dying -= OnEnemyDying;
        _moneyCounter.AddMoney(enemy.Reward);
    }

    public void NextWaves()
    {
        SetWave(++_currentWaveNumber);
        _spawned = 0;
        _currentEnemyIndex = 0;
        _checkTimerWaveSpawn = false;
    }
}

[System.Serializable]
public class Wavesss
{
    [SerializeField] private WavesssSettings[] _wavesssSettings;

    public WavesssSettings[] wavesSettings { get => _wavesssSettings; }
}

[System.Serializable]
public class WavesssSettings
{
    public GameObject Template;
    public float Delay;
    //public int Count;
}

