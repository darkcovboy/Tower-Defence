using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BarracksTower : Tower
{
    [SerializeField] private int[] _maxWarriors;
    [SerializeField] private WarriorsSpawner _warriorsSpawner;
    [SerializeField] private WarriorChanger _warriorChanger;
    [SerializeField] private Transform _target;
    [SerializeField] private Transform _points;
    [SerializeField] private List<Transform> _pointWarriors;

    public GameObject WarriorPrefab => _warriorChanger.gameObject;
    public int WarriorHealth => _warriorChanger.Warrior.MaxHealth;
    public UnityAction OnWarriorDied;

    private int _currentWarriors = 0;
    private bool _canSpawnWarriors = true;

    private void Awake()
    {
        _points.position = LookAtTarget.position;
    }

    private void Start()
    {
        _points.position = LookAtTarget.position;
    }

    private void OnEnable()
    {
        OnWarriorDied += OnWarriorDie;
        _points.position = LookAtTarget.position;
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
        Debug.Log(_points.position + " " + newPosition.position);
        _points.position = newPosition.position;
        Debug.Log(_points.position + " " + newPosition.position);

        for (int i = 0; i < _maxWarriors[Level]; i++)
        {
            _warriorsSpawner.ChangeTarget(_pointWarriors[i], i);
        }
    }

    public void ChangeWarrior()
    {
        _warriorsSpawner.UpgradeWarriors();
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

        yield return new WaitForSeconds(TowerDataConfig.Delays[Level]);

        _canSpawnWarriors = true;
    }

    private void SpawnWarriors(int index)
    {
        _warriorsSpawner.SpawnWarrior(_pointWarriors[index], gameObject);
    }
}
