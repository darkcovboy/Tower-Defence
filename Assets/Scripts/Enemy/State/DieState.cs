using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class DieState : State
{
    private EnemyAnimations _enemyAnimations;
    private Coroutine _coroutine;

    private void Awake()
    {
        _enemyAnimations = GetComponent<EnemyAnimations>();
    }

    private void OnEnable()
    {
        _enemyAnimations.DeathAnimation(true);

        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
        _coroutine = StartCoroutine(Die());
        //Destroy(gameObject,3f);
    }

    private void OnDisable()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
        _enemyAnimations.DeathAnimation(false);
    }

    IEnumerator Die()
    {
        var WaitForSeconds = new WaitForSeconds(3f);
        yield return WaitForSeconds;
        gameObject.SetActive(false);
    }
}

