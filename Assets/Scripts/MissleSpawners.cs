using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissleSpawners : ObjectPool
{
    [SerializeField] private Missle _misslePrefab;

    public Transform StartPosition;

    private void Start()
    {
        Initialize(_misslePrefab.gameObject);
    }

    public void PushMissle(Transform target, Enemy enemy, int damage)
    {
        if(TryGetObject(out GameObject missle))
        {
            Debug.Log("PushMissle");
            missle.SetActive(true);
            missle.transform.position = StartPosition.position;
            missle.GetComponent<Missle>().Create(target, enemy, damage);
        }
    }
}
