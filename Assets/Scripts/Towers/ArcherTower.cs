using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherTower : Tower
{
    [SerializeField] private List<float> _attackRate;
    [SerializeField] private List<float> _damage;
    [SerializeField] private Missle _misslePrefab;
    [SerializeField] private Transform _target;
    [SerializeField] private Transform _targetMissle;

    private Enemy _enemy;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Object is found");
        if(other.gameObject.TryGetComponent(out Enemy enemy))
        {
            if(_target == null)
            {
                _target = enemy.transform;
                _enemy = enemy;
                StartCoroutine(ShootDownDelay());
            }

            Debug.Log("Enemy is found");
        }
    }

    private IEnumerator ShootDownDelay()
    {
        while (_enemy.Health > 0)
        {
            Shoot();
            yield return new WaitForSeconds(_attackRate[Level]);
        }
    }

    private void Shoot()
    {
        var missle = Instantiate(_misslePrefab, _targetMissle);
        missle.Create(_target, _enemy, _damage[Level]);
    }
}
