using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missle : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _distanceBetweenTargetAndEnemy;

    private float _damage;
    private Transform _target;
    private Enemy _enemy;

    private void OnDisable()
    {
        StopCoroutine(MoveToTarget());
    }

    private void Update()
    {
        if(_target != null)
        {
            transform.LookAt(_target);
        }
    }

    private IEnumerator MoveToTarget()
    {
        while(Vector3.Distance(transform.position, _target.position) > _distanceBetweenTargetAndEnemy)
        {
            //transform.LookAt(_target);
            transform.position = Vector3.MoveTowards(transform.position, _target.position, Time.deltaTime * _speed);
            yield return null;
        }

        _enemy.TakeDamage(_damage);
        Destroy(gameObject);
    }

    public void Create(Transform target,Enemy enemy, float damage)
    {
        _target = target;
        _damage = damage;
        _enemy = enemy;
        StartCoroutine(MoveToTarget());
    }
}
