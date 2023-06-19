using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackWarriorState : State
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
            Attack(_enemy.Warrior);
            _lastAttackTime = _delay;
        }
        _lastAttackTime -= Time.deltaTime;
    }
    
    private void Attack(Warrior warrior)
    {
        Vector3 direction = warrior.transform.position - transform.position;
        transform.forward = direction;
        _enemyAnimations.AttackAnimation(true);
        warrior.ApplyDamage(_enemy.Damage);
    }

    public void ResetAttackTime()
    {
        _lastAttackTime = 0f;
    }
}
