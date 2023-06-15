using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class DieState : State
{
    private EnemyAnimations _enemyAnimations;

    private void Awake()
    {
        _enemyAnimations = GetComponent<EnemyAnimations>();
    }

    private void OnEnable()
    {
        _enemyAnimations.DeathAnimation(true);
        Destroy(gameObject,3f);
    }

    private void OnDisable()
    {
        _enemyAnimations.DeathAnimation(false);
    }
}

