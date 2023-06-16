using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherTower : Tower
{
    [SerializeField] private Transform _target;

    private Enemy _enemy;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent(out Enemy enemy))
        {
            if(_target == null)
            {
                _target = enemy.transform;
                _enemy = enemy;
                StartCoroutine(ShootDownDelay());
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Enemy enemy))
        {
            if (_target == null)
            {
                _target = enemy.transform;
                _enemy = enemy;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _target = null;
    }

    private IEnumerator ShootDownDelay()
    {
        while (_enemy.Health > 0)
        {
            Shoot();
            yield return new WaitForSeconds(AttackRates[Level]);
        }
    }

    private void Shoot()
    {
        MissleSpawners.PushMissle(_target, _enemy, Damages[Level]);
    }
}
