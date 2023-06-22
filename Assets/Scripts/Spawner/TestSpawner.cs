using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TestSpawner : MonoBehaviour
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

    public event UnityAction AllEnemysSpawned;
    public event UnityAction<int, int> EnemyCountChanged;

    private void Start()
    {
        SetWave(_currentWaveNumber);
    }

    private void Update()
    {
        if (_currentWave == null)
        {
            //Debug.Log("вышли");
            return;
        }

        _timeAfterlastSpawn += Time.deltaTime;

        if (_timeAfterlastSpawn >= _waves[_currentWaveNumber].wavesSettings[_currentEnemyIndex].Delay)
        {
            InstantiateEnemy();
            _spawned++;
            _timeAfterlastSpawn = 0;
            EnemyCountChanged?.Invoke(_spawned, _waves[_currentWaveNumber].wavesSettings[_currentEnemyIndex].Count);
            _currentEnemyIndex++;
        }

        if (_waves[_currentWaveNumber].wavesSettings.Length <= _spawned)
        {
            if (_waves.Length > _currentWaveNumber + 1)
            {
                NextWaves();
            }

            else
            {
                _currentWave = null;
                _currentEnemyIndex = 0;
                Debug.Log(_currentWave);
            }
        }
    }

    private void InstantiateEnemy()
    {
        int indexArray = Random.Range(0, _spawnPoint.Length);
        //int indexEnemy = Random.Range(0, _waves[);
        Enemy enemy = Instantiate(/*_currentWave.Template[indexEnemy]*/_waves[_currentWaveNumber].wavesSettings[_currentEnemyIndex].Template, _spawnPoint[indexArray].position, _spawnPoint[indexArray].rotation, _container).GetComponent<Enemy>();
        enemy.Init(_player, _warrior);
        enemy.Dying += OnEnemyDying;
        enemy.GetIndexToArray(indexArray);
    }

    private void SetWave(int index)
    {
        _currentWave = _waves[index];
    }

    private void OnEnemyDying(Enemy enemy)
    {
        enemy.Dying -= OnEnemyDying;
        _player.AddMoney(enemy.Reward);
    }

    private void NextWaves()
    {
        SetWave(++_currentWaveNumber);
        _spawned = 0;
        _currentEnemyIndex = 0;
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
    public int Count;
}

