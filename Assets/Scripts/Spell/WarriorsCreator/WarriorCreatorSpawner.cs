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

    public void PushWarrior(Transform endPosition, int lifeTime)
    {
        if (TryGetObject(out GameObject warrior))
        {
            Debug.Log("Yes");
            warrior.SetActive(true);
            warrior.transform.position = endPosition.position;
            warrior.GetComponent<Warrior>().SetWarriorLifeTime(lifeTime, endPosition);
        }
    }
}
