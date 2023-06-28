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
    private Coroutine _shootCoroutine;
    public ConfigData _configData;
    /*
    private void Awake()
    {
        Debug.Log(_configData.ArcherRadius);
        switch(_towerType)
        {
            case ShootingTowerType.Canon:
                Costs = _configData.CanonTowerCost;
                Delay = _configData.CanonTowerDelays;
                Damages = _configData.CanonTowerDamages;
                Radius = _configData.CanonTowerRadius;
                break;
            case ShootingTowerType.Archer:
                Costs = _configData.ArcherCost;
                Delay = _configData.ArcherDelays;
                Damages = _configData.ArcherDamages;
                Radius = _configData.ArcherRadius;
                break;
            case ShootingTowerType.FireMage:
                Costs = _configData.FireMageCost;
                Delay = _configData.FireMageDelays;
                Damages = _configData.FireMageDamages;
                Radius = _configData.FireMageRadius;
                break;
            case ShootingTowerType.IceMage:
                Costs = _configData.IceMageCost;
                Delay = _configData.IceMageDelays;
                Damages = _configData.IceMageDamages;
                Radius = _configData.IceMageRadius;
                break;
            default:
                throw new ArgumentNullException();
        }
    }
    */

    private void Update()
    {
        if (_target == null && _watchers[Level] == null)
            return;

        _watchers[Level].transform.LookAt(_target);
        _watchers[Level].transform.rotation = Quaternion.Euler(0f, _watchers[Level].transform.localEulerAngles.y, 0f);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Enemy enemy))
        {
            if (_target == null)
            {
                _target = enemy.transform;
                _enemy = enemy;

                if(_shootCoroutine == null)
                {
                    _shootCoroutine = StartCoroutine(ShootDownDelay());
                }
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

                if (_shootCoroutine == null)
                {
                    _shootCoroutine = StartCoroutine(ShootDownDelay());
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Enemy enemy))
        {
            Stop();
        }
    }

    private IEnumerator ShootDownDelay()
    {
        while (_enemy.CurrentHealth > 0)
        {
            Shoot();

            if (_particleSystems.Length > 0)
                _particleSystems[Level].Play();

            yield return new WaitForSeconds(Delay[Level]);
        }

        Stop();
    }

    private void Stop()
    {
        _target = null;
        _enemy = null;
        StopCoroutine(_shootCoroutine);
        _shootCoroutine = null;
    }

    private void Shoot()
    {
        MissleSpawners.PushMissle(_target, _enemy, Damages[Level], StartPositions[Level]);
    }
}
