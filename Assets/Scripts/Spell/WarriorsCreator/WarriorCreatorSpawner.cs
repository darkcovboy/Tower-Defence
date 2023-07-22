using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorCreatorSpawner : ObjectPool
{
    [SerializeField] private Warrior _warriorPrefab;

    private void Start()
    {
        Initialize(_warriorPrefab.gameObject);
    }

    public void PushMissle(Vector3 endPosition)
    {
        if (TryGetObject(out GameObject warrior))
        {
            warrior.SetActive(true);
            warrior.transform.position = endPosition;
        }
    }
}
