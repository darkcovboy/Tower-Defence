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

    public void PushWarrior(Vector3 endPosition, int lifeTime)
    {
        if (TryGetObject(out GameObject warrior))
        {
            warrior.SetActive(true);
            warrior.transform.position = endPosition;
            warrior.GetComponent<Warrior>().SetWarriorLifeTime(lifeTime);
        }
    }
}
