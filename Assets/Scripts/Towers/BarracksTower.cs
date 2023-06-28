using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BarracksTower : Tower
{
    [SerializeField] private int[] _maxWarriors;
    [SerializeField] private WarriorsSpawner _warriorsSpawner;
    [SerializeField] private List<GameObject> _warriorPrefabs;
    [SerializeField] private Transform _target;
    [SerializeField] private Transform _points;

    public GameObject WarriorPrefab => _warriorPrefabs[Level];
    public UnityAction OnWarriorDied;
    public ConfigData _configData;

    private int _currentWarriors = 0;
    private bool _canSpawnWarriors = true;
    
    [SerializeField] private List<Transform> _pointWarriors;

    private void Start()
    {
        /*
        for (int i = 0; i < _points.childCount; i++)
        {
            Debug.Log(_points.GetChild(i).transform);
            _pointWarriors.Add(_points.GetChild(i).transform);
            Debug.Log(_pointWarriors[i]);
        }
        */
    }

    private void OnEnable()
    {
        OnWarriorDied += OnWarriorDie;
    }

    private void OnDisable()
    {
        OnWarriorDied -= OnWarriorDie;
    }

    private void Update()
    {
        if (_currentWarriors > 0 || _canSpawnWarriors == false)
        {
            return;
        }

        StartCoroutine(SpawnWarriorsDelay());
        StopCoroutine(SpawnWarriorsDelay());
    }

    public void ChangePoint(Transform newPosition)
    {
        _points.position = newPosition.position;

        for (int i = 0; i < _maxWarriors[Level]; i++)
        {
            _warriorsSpawner.ChangeTarget(_pointWarriors[i]);
        }
    }

    private void OnWarriorDie()
    {
        _currentWarriors--;
    }

    private IEnumerator SpawnWarriorsDelay()
    {
        _canSpawnWarriors = false;

        for (int i = 0; i < _maxWarriors[Level]; i++)
        {
            SpawnWarriors(i);
            _currentWarriors++;
        }

        yield return new WaitForSeconds(Delay[Level]);

        _canSpawnWarriors = true;
    }

    private void SpawnWarriors(int index)
    {
        _warriorsSpawner.SpawnWarrior(Damages[Level], _pointWarriors[index], gameObject);
    }
}
