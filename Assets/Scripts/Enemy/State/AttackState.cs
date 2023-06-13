using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AttackState : State
{
    [SerializeField] private int _damage;
    [SerializeField] private float _delay;
    [SerializeField] private Enemy _enemy;
    [SerializeField] private DistanceTransitions _distanceTransitions;
    [SerializeField] private ReturnTransition _returnTransition;
    [SerializeField] private EnemyMoverState _enemyMoverState;
    [SerializeField] private AttackState _attackState;

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
            if (_distanceTransitions.Flag == true)
            {
                Attack(Warrior);
                _lastAttackTime = _delay;

                if (Warrior.gameObject.activeSelf == false) 
                {
                    _distanceTransitions.Flag = false;
                    _distanceTransitions.enabled = true;
                    _enemyMoverState.enabled = true;
                    _attackState.enabled = false;

                    _animator.Play("Run");
                }
            }
            else
            {
                Attack(Target);
                _lastAttackTime = _delay;
            }
        }

        _lastAttackTime -= Time.deltaTime;
    }

    private void Attack(Player target)
    {
        _animator.Play("Attacks");
        target.ApplyDamage(_damage);
        //_enemy.TakeDamage(10);
    }

    private void Attack(Warrior warrior)
    {
        _animator.Play("Attacks");
        warrior.ApplyDamage(_damage);
    }
}
