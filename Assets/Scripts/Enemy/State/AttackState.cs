using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AttackState : State
{
    [SerializeField] private float _delay;
    [SerializeField] private Enemy _enemy;

    private float _lastAttackTime;
    private EnemyAnimations _enemyAnimations;

    private void Start()
    {
        _enemyAnimations = GetComponent<EnemyAnimations>();
    }

    private void Update()
    {
        if (_lastAttackTime <= 0)
        {
                Attack(Target);
                _lastAttackTime = _delay;
        }

        _lastAttackTime -= Time.deltaTime;
    }

    private void Attack(Player target)
    {
        Debug.Log("бить");
        _enemyAnimations.AttackAnimation(true);
        target.ApplyDamage(_enemy.Damage);
    }
}
