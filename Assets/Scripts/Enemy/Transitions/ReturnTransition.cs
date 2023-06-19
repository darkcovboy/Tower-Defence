using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnTransition : Transitions
{
    [SerializeField] private Enemy _enemy;
    [SerializeField]private AttackWarriorState _attackWarriorState;

    private EnemyAnimations _enemyAnimations;

    private void Start()
    {
        _enemyAnimations = GetComponent<EnemyAnimations>();
    }

    private void Update()
    {
        if (_enemy.Warrior.DieWarrior == true)
        {
            _enemy.TargetNull();
            _attackWarriorState.ResetAttackTime();
            _enemyAnimations.AttackAnimation(false);
            NeedTransit = true;
        }
    }
}