using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using Zenject;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour, ISpawnedHandler, IDiedHandler
{
    [SerializeField] private WavesConfig _wavesConfig;
    [SerializeField] private EnemyFactory _enemyFactory;
    [SerializeField] protected Wavesss[] _waves;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Player _player;
    [SerializeField] private Transform _container;

    private MoneyCounter _moneyCounter;
    private WaveConfig[] _waveSettings;
    private Waypoints _waypoints;

    private int _enemyCount = 0;

    public event Action AllEnemysSpawned;
    public event Action AllEnemysDied;
    public event UnityAction<int, int> EnemyCountChanged;
    public event UnityAction<int, int> WaveChanged;

    [Inject]
    public void Init(MoneyCounter moneyCounter, Waypoints waypoints)
    {
        _moneyCounter = moneyCounter;
        _waypoints = waypoints;
    }

    private void Start()
    {
        //SetWave(CurrentWaveNumber);
        _waveSettings = (WaveConfig[])_wavesConfig.Waves.Clone();
        CalculateEnemyCount();
        StartCoroutine(SpawnWaves());
    }

    private IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(_wavesConfig.PrepareToStartTime);

        foreach (WaveConfig wave in _waveSettings)
        {
            int countEnemiesSpawned = 0;
            foreach (EnemySpawn enemySpawn in wave.EnemySpawns)
            {
                InstantiateEnemy(enemySpawn.EnemyPrefab);
                countEnemiesSpawned++;
                EnemyCountChanged?.Invoke(countEnemiesSpawned, wave.EnemySpawns.Length);
                yield return new WaitForSeconds(enemySpawn.SpawnDelay);
            }

            yield return new WaitForSeconds(wave.TimeBetweenWaves);
        }

        AllEnemysSpawned?.Invoke();
    }

    private void CalculateEnemyCount()
    {
        foreach (WaveConfig wave in _waveSettings)
        {
            _enemyCount += wave.EnemySpawns.Length;
        }
    }

    private void InstantiateEnemy(Enemy prefab)
    {
        Enemy enemy = _enemyFactory.Get(prefab, _spawnPoint, _waypoints);
        enemy.Init(_player);
        enemy.Dying += OnEnemyDying;
        _enemyCount++;
    }
    private void OnEnemyDying(Enemy enemy)
    {
        enemy.Dying -= OnEnemyDying;
        _moneyCounter.AddMoney(enemy.Reward);
        _enemyCount--;

        if(_enemyCount == 0)
            AllEnemysDied?.Invoke();
    }

    /*
    private Wavesss _currentWave;
    private float _timeAfterlastSpawn;
    private int _spawned;
    private int _currentEnemyIndex;
    private bool _checkTimerWaveSpawn = false;
    private int _maxWaveCount;
    private bool _allEnemySpawn = false;
    private WaitForSeconds _waitForSeconds = new WaitForSeconds(3f);
    private Coroutine _coroutine; 

    public int EnemySpawnCount { get; private set; }
    public int CurrentWaveNumber { get; private set; } = 0;
     
    private void SetWave(int index)
    {
        _currentWave = _waves[index];
        _maxWaveCount = _waves.Length;
        WaveChanged?.Invoke(++index, _maxWaveCount);
    }

    public void NextWaves()
    {
        SetWave(++CurrentWaveNumber);
        _spawned = 0;
        _currentEnemyIndex = 0;
        _checkTimerWaveSpawn = false;
    }

    IEnumerator AllEnemysDying()
    {
        yield return _waitForSeconds;
        _allEnemySpawn = true;
        
    }

    private void Update()
    {
        if (_allEnemySpawn == false)
        {
            if (_currentWave == null || _currentWave.wavesSettings == null)
            {
                return;
            }

            _timeAfterlastSpawn += Time.deltaTime;

            if (_checkTimerWaveSpawn == false)
            {
                if (_timeAfterlastSpawn >= _waves[CurrentWaveNumber].wavesSettings[_currentEnemyIndex].Delay)
                {
                    //InstantiateEnemy();
                    _spawned++;
                    _timeAfterlastSpawn = 0;
                    EnemyCountChanged?.Invoke(_spawned, _waves[CurrentWaveNumber].wavesSettings.Length);
                    _currentEnemyIndex++;
                    EnemySpawnCount++;
                }
            }

            if (_waves[CurrentWaveNumber].wavesSettings.Length <= _spawned)
            {
                if (_waves.Length > CurrentWaveNumber + 1)
                {
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
    }
    */
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
}

