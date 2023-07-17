using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class ShootingTower : Tower
{
    [SerializeField] protected MissleSpawners MissleSpawners;
    [SerializeField] private Transform _target;
    [SerializeField] private ParticleSystem[] _particleSystems;
    [SerializeField] private GameObject[] _watchers;

    private Enemy _enemy;

    private Quaternion _startRotation;

    private void Start()
    {
        if (_watchers[Level] != null)
            _startRotation = _watchers[Level].transform.rotation;
    }

    private void OnEnable()
    {
        StartCoroutine(ShootDelay());
    }

    private void OnDisable()
    {
        StopCoroutine(ShootDelay());
    }

    private void Update()
    {
        if (_watchers[Level] == null || _target == null)
        {
            _watchers[Level].transform.rotation = _startRotation;
            return;
        }

        _watchers[Level].transform.LookAt(_target);
        _watchers[Level].transform.rotation = Quaternion.Euler(0f, _watchers[Level].transform.localEulerAngles.y, 0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Enemy enemy))
        {
            if (_target == null && enemy.CurrentHealth > 0)
            {
                _target = enemy.transform;
                _enemy = enemy;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Enemy enemy))
        {
            if (_target == null && enemy.CurrentHealth > 0)
            {
                _target = enemy.transform;
                _enemy = enemy;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Enemy enemy))
        {
            if (enemy == _enemy)
                Stop();
        }
    }

    private IEnumerator ShootDelay()
    {
        while(true)
        {
            if(_target != null)
            {
                if(_enemy.CurrentHealth > 0)
                {
                    Shoot();

                    if (_particleSystems.Length > 0)
                        _particleSystems[Level].Play();

                    yield return new WaitForSeconds(TowerDataConfig.Delays[Level]);
                }
                else
                {
                    Stop();
                }
            }
            else
            {
                yield return null;
            }
        }
    }

    private void Stop()
    {
        _target = null;
        _enemy = null;
    }

    private void Shoot()
    {
        MissleSpawners.PushMissle(_target, _enemy, TowerDataConfig.Damages[Level], StartPositions[Level]);
    }
}
