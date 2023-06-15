using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CelebrationState : State
{
    private EnemyAnimations _enemyAnimations;

    private void Awake()
    {
        _enemyAnimations = GetComponent<EnemyAnimations>();
    }

    private void OnEnable()
    {
        _enemyAnimations.CelebrationAnimation(true);
    }

    private void OnDisable()
    {
        _enemyAnimations.CelebrationAnimation(false);
    }
}
