using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarracksTower : Tower
{
    [SerializeField] private GameObject[] _warriorPrefabs;
    [SerializeField] private int[] _maxWarriors;
    [SerializeField] private WarriorsSpawner _warriorsSpawner;
    [SerializeField] private Transform[] _pointWarriors;
    [SerializeField] private Transform _target;

    public GameObject WarriorPrefab => _warriorPrefabs[Level];

    private int _currentWarriors = 0;
    private bool _canSpawnWarriors = true;


    private void Update()
    {
        if (_currentWarriors > 0 || _canSpawnWarriors == false)
        {
            return;
        }

        StartCoroutine(SpawnWarriorsDelay());
        StopCoroutine(SpawnWarriorsDelay());
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
        _warriorsSpawner.SpawnWarrior(Damages[Level], _pointWarriors[index]);
    }
}
