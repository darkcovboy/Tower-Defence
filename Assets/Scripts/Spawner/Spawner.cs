using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Zenject;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour, ISpawnedHandler, IDiedHandler
{
    [SerializeField] private WavesConfig _wavesConfig;
    [SerializeField] protected Wavesss[] _waves;
    [SerializeField] private Transform[] _spawnPoint;
    [SerializeField] private Player _player;
    [SerializeField] private Warrior _warrior;
    [SerializeField] private Transform _container;

    private Wavesss _currentWave;
    private float _timeAfterlastSpawn;
    private int _spawned;
    private int _currentEnemyIndex;
    private bool _checkTimerWaveSpawn = false;
    private int _maxWaveCount;
    private MoneyCounter _moneyCounter;
    private bool _allEnemySpawn = false;
    private WaitForSeconds _waitForSeconds = new WaitForSeconds(3f);
    private Coroutine _coroutine;
    private WaveConfig[] _waveConfigs;

    private int _enemyCount = 0;
    public int EnemySpawnCount { get; private set; }
    public int CurrentWaveNumber { get; private set; } = 0;

    public event Action AllEnemysSpawned;
    public event Action AllEnemysDied;
    public event UnityAction<int, int> EnemyCountChanged;
    public event UnityAction<int, int> WaveChanged;

    [Inject]
    public void Init(MoneyCounter moneyCounter)
    {
        _moneyCounter = moneyCounter;
    }

    private void Start()
    {
        //SetWave(CurrentWaveNumber);
        _waveConfigs = (WaveConfig[])_wavesConfig.Waves.Clone();
        StartCoroutine(SpawnWaves());
    }

    private IEnumerator SpawnWaves()
    {
        foreach (WaveConfig wave in _waveConfigs)
        {
            foreach (EnemySpawn enemySpawn in wave.EnemySpawns)
            {
                //Создание врага и прочее из метода intstantiateEnemy

                yield return new WaitForSeconds(enemySpawn.SpawnDelay);
            }

            yield return new WaitForSeconds(wave.TimeBetweenWaves);
        }
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
                    InstantiateEnemy();
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

    private void InstantiateEnemy()
    {
        int indexArray = Random.Range(0, _spawnPoint.Length);
        Enemy enemy = Instantiate(_waves[CurrentWaveNumber].wavesSettings[_currentEnemyIndex].Template, _spawnPoint[indexArray].position, _spawnPoint[indexArray].rotation, _container).GetComponent<Enemy>();
        enemy.Init(_player, _warrior);
        enemy.Dying += OnEnemyDying;
        enemy.GetIndexToArray(indexArray);
        _enemyCount++;
    }

    private void SetWave(int index)
    {
        _currentWave = _waves[index];
        _maxWaveCount = _waves.Length;
        WaveChanged?.Invoke(++index, _maxWaveCount);
    }

    private void OnEnemyDying(Enemy enemy)
    {
        enemy.Dying -= OnEnemyDying;
        _moneyCounter.AddMoney(enemy.Reward);
        _enemyCount--;

        if (CurrentWaveNumber == _waves.Length - 1)
        {
            if (_enemyCount <= 0)
            {
                if (_coroutine != null)
                {
                    StopCoroutine(_coroutine);
                }
                _coroutine = StartCoroutine(AllEnemysDying());
            }
            else
                return;
        }
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
        AllEnemysDied?.Invoke();
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
}

