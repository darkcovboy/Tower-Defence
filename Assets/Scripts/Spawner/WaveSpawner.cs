using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] protected Waves[] _waves;
    [SerializeField] private Player _target;
    [SerializeField] private Warrior _warrior;

    private int _currentEnemyIndex;
    private int _currentWaveIndex;
    private int _enemiesLeftToSpawn;

    public int EnemiesLeftToSpawn => _enemiesLeftToSpawn;

    public event UnityAction <int,int> EnemyCountChanged;

    private void Start()
    {
        _enemiesLeftToSpawn = _waves[0].wavesSettings.Length;
        LaunchWave();
    }

    private IEnumerator SpawnEnemyInWave()
    {
        if (_enemiesLeftToSpawn > 0)
        {
            int indexArray = Random.Range(0, _waves[_currentWaveIndex].wavesSettings[_currentEnemyIndex].NedeedSpawner.Length);
            yield return new WaitForSeconds(_waves[_currentWaveIndex].wavesSettings[_currentEnemyIndex].SpawnDelay);
            Enemy enemy = Instantiate(_waves[_currentWaveIndex].wavesSettings[_currentEnemyIndex].Enemy, _waves[_currentWaveIndex].wavesSettings[_currentEnemyIndex].NedeedSpawner[indexArray].transform.position, Quaternion.identity).GetComponent<Enemy>();
            enemy.Init(_target,_warrior);
            enemy.Dying += OnEnemyDying;
            enemy.GetIndexToArray(indexArray);
            _enemiesLeftToSpawn--;
            _currentEnemyIndex++;
            EnemyCountChanged?.Invoke(_currentEnemyIndex, _waves[_currentWaveIndex].wavesSettings.Length);
            StartCoroutine(SpawnEnemyInWave());
        }
        else
        {
            if (_currentWaveIndex < _waves.Length - 1)
            {
                _currentWaveIndex++;
                _enemiesLeftToSpawn = _waves[_currentWaveIndex].wavesSettings.Length;
                _currentEnemyIndex = 0;
            }
        }
    }

    private void OnEnemyDying(Enemy enemy)
    {
        enemy.Dying -= OnEnemyDying;
        _target.AddMoney(enemy.Reward);
    }

    public void LaunchWave()
    {
        StartCoroutine(SpawnEnemyInWave());
    }
}

[System.Serializable]
public class Waves
{
    [SerializeField] private WavesSettings[] _wavesSettings;

    public WavesSettings[] wavesSettings { get => _wavesSettings; }
}

[System.Serializable]
public class WavesSettings
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private GameObject[] _nedeedSpawner;
    [SerializeField] private float _spawnDelay;

    public GameObject Enemy { get => _enemy; }
    public GameObject[] NedeedSpawner { get => _nedeedSpawner; }
    public float SpawnDelay { get => _spawnDelay; }
}
