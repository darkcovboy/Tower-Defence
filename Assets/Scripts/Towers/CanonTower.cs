using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonTower : Tower
{
    [SerializeField] private Transform _target;
    [SerializeField] private ParticleSystem[] _particleSystems;

    private Enemy _enemy;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Enemy enemy))
        {
            if (_target == null)
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
            Debug.Log("ShootDownDelay");
            Shoot();
            _particleSystems[Level].Play();
            yield return new WaitForSeconds(AttackRates[Level]);
        }

        StopCoroutine(ShootDownDelay());
    }

    private void Shoot()
    {
        MissleSpawners.PushMissle(_target, _enemy, Damages[Level]);
    }
}
