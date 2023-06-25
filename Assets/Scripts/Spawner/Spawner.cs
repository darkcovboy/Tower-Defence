using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Wave> _waves;
    [SerializeField] private Transform/*[]*/ _spawnPoint;
    [SerializeField] private Player _player;
    [SerializeField] private Warrior _warrior;
    [SerializeField] private Transform _container;

    private Wave _currentWave;
    private int _currentWaveNumber = 0;
    private float _timeAfterlastSpawn;
    private int _spawned;

    public event UnityAction AllEnemysSpawned;
    public event UnityAction<int, int> EnemyCountChanged;

    private void Start()
    {
        SetWave(_currentWaveNumber);
    }

    private void Update()
    {
        if (_currentWave == null||_currentWave.Template == null)
        {
            Debug.Log("до");
            return;
            Debug.Log("после");
        }

        _timeAfterlastSpawn += Time.deltaTime;

        if (_timeAfterlastSpawn >= _currentWave.Delay)
        {
            InstantiateEnemy();
            _spawned++;
            _timeAfterlastSpawn = 0;
            EnemyCountChanged?.Invoke(_spawned, _currentWave.Count);
        }

        if (_currentWave.Count <= _spawned)
        {
            if (_waves.Count > _currentWaveNumber + 1)
                NextWaves();

            else
                _currentWave = null;
        }
    }

    private void InstantiateEnemy()
    {
        //int indexArray = Random.Range(0, _spawnPoint.Length);
        //int indexEnemy = Random.Range(0, _currentWave.Template.Length);
        Enemy enemy = Instantiate(_currentWave.Template/*[indexEnemy]*/, _spawnPoint/*[indexArray]*/.position, _spawnPoint/*[indexArray]*/.rotation, _container).GetComponent<Enemy>();
        enemy.Init(_player, _warrior);
            enemy.Dying += OnEnemyDying;
            //enemy.GetIndexToArray(indexArray);

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
    }
}

[System.Serializable]
public class Wave
{
    public GameObject/*[] */Template;
    public float Delay;
    public int Count;
}

