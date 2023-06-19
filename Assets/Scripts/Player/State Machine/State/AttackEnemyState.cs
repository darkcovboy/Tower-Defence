using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEnemyState : State
{
    [SerializeField] private float _delay;
    [SerializeField] private Warrior _warrior;

    private float _lastAttackTime;
    private WarriorAnimations _warriorAnimations;

    private void Start()
    {
        _warriorAnimations = GetComponent<WarriorAnimations>();
    }

    private void Update()
    {
        if (_lastAttackTime <= 0)
        {
            Attack(_warrior.Enemy);
            _lastAttackTime = _delay;
        }
        _lastAttackTime -= Time.deltaTime;
    }

    private void Attack(Enemy enemy)
    {
        _warriorAnimations.AttackAnimation(true);
        enemy.TakeDamage(_warrior.Damage);
    }

    public void ResetAttackTime()
    {
        _lastAttackTime = 0f;
    }
}
