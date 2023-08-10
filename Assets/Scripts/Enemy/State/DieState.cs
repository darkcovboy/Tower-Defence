using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Plugins.Audio.Core;
using Plugins.Audio.Utils;

[RequireComponent(typeof(Animator))]
public class DieState : State
{
    [SerializeField] private ParticleSystem _dieEffect;
    [SerializeField] private GameObject _praticle;
    [SerializeField] private AudioDataProperty _key;

    private EnemyAnimations _enemyAnimations;
    private Coroutine _coroutine;

    private readonly WaitForSeconds _waitSeconds = new WaitForSeconds(3f);

    private void Awake()
    {
        _enemyAnimations = GetComponent<EnemyAnimations>();
    }

    private void OnEnable()
    {
        _enemyAnimations.DeathAnimation(true);
        Instantiate(_dieEffect, _praticle.transform.position,Quaternion.identity,gameObject.transform);

        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _coroutine = StartCoroutine(Die());
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
        if(TryGetComponent<SourceAudio>(out SourceAudio audioSource))
        {
            audioSource.Play(_key.Key);
        }

        yield return _waitSeconds;
        gameObject.Deactivate();
    }
}

