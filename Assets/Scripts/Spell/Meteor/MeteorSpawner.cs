using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : ObjectPool
{
    [SerializeField] private Missle _misslePrefab;

    private void Start()
    {
        Initialize(_misslePrefab.gameObject);
    }

    public void PushMissle(Transform startPosition, Vector3 endPosition, int damage)
    {
        if (TryGetObject(out GameObject missle))
        {
            missle.SetActive(true);
            missle.transform.position = startPosition.position;
            missle.GetComponent<MeteorMissle>().Create(endPosition, damage);
        }
    }
}
