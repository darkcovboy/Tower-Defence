using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissleSpawners : ObjectPool
{
    [SerializeField] private Missle _misslePrefab;

    private void Start()
    {
        Initialize(_misslePrefab.gameObject);
    }

    public void PushMissle(Transform target, Enemy enemy, int damage, Transform startPosition)
    {
        if(TryGetObject(out GameObject missle) && target != null)
        {
            missle.SetActive(true);
            missle.transform.position = startPosition.position;
            missle.GetComponent<Missle>().Create(target, enemy, damage);
        }
    }
}
