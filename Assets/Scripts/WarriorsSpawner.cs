using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorsSpawner : ObjectPool
{
    [SerializeField] private BarracksTower _barracksTower;
    [SerializeField] private Transform _target;
    private GameObject _warriorPrefab;

    private void Start()
    {
        _warriorPrefab = _barracksTower.WarriorPrefab;

        Initialize(_warriorPrefab);
    }

    public void SpawnWarrior(int damage, Transform target, GameObject barracks)
    {
        //if (TryGetObject(out GameObject warrior))
        //{
        //    warrior.GetComponent<Warrior>().SendData(damage, target, barracks.GetComponent<BarracksTower>());
        //    warrior.SetActive(true);
        //    warrior.transform.position = transform.position;
        //}
    }
}
