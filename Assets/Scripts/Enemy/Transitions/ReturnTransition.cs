using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnTransition : Transition
{
    [SerializeField] private Enemy _enemy;

    private EnemyAnimations _enemyAnimations;

    private void Start()
    {
        _enemyAnimations = GetComponent<EnemyAnimations>();
    }

    private void Update()
    {
        if (_enemy.Warrior.gameObject.activeSelf == false)
        {
            _enemyAnimations.AttackAnimation(false);
            NeedTransit = true;
        }
    }
}