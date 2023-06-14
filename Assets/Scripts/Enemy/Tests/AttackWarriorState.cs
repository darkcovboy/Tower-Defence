using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackWarriorState : State
{
    [SerializeField] private int _damage;
    [SerializeField] private float _delay;
    [SerializeField] private Enemy _enemy;

    private float _lastAttackTime;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
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
        _animator.Play("Attacks");
        warrior.ApplyDamage(_damage);
    }
}
