using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class ShootingTower : Tower
{
    [SerializeField] protected MissleSpawners MissleSpawners;
    [SerializeField] protected Transform Target;
    [SerializeField] private ParticleSystem[] _particleSystems;
    [SerializeField] private GameObject[] _watchers;

    protected Enemy Enemy;

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
        if (_watchers[Level] == null || Target == null)
        {
            _watchers[Level].transform.rotation = _startRotation;
            return;
        }

        _watchers[Level].transform.LookAt(Target);
        _watchers[Level].transform.rotation = Quaternion.Euler(0f, _watchers[Level].transform.localEulerAngles.y, 0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Enemy enemy))
        {
            if (Target == null && enemy.CurrentHealth > 0)
            {
                Target = enemy.transform;
                Enemy = enemy;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Enemy enemy))
        {
            if (Target == null && enemy.CurrentHealth > 0)
            {
                Target = enemy.transform;
                Enemy = enemy;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Enemy enemy))
        {
            if (enemy == Enemy)
                Stop();
        }
    }

    private IEnumerator ShootDelay()
    {
        while(true)
        {
            if(Target != null)
            {
                if(Enemy.CurrentHealth > 0)
                {
                    Shoot();

                    if (_particleSystems.Length > 0)
                        _particleSystems[Level].Play();

                    if (_watchers[Level].TryGetComponent<Animator>(out Animator animator))
                    {
                        animator.Play("Shoot");
                    }

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
        Target = null;
        Enemy = null;
    }

    protected virtual void Shoot()
    {
        MissleSpawners.PushMissle(Target, Enemy, TowerDataConfig.Damages[Level], Level, StartPositions[Level]);
    }
}
